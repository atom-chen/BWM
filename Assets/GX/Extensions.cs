﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using GX;

public static class Extensions
{
	#region Random
	private static readonly System.Random random = new System.Random();

	/// <summary>
	/// 得到随机的bool值
	/// </summary>
	/// <param name="random"></param>
	/// <param name="successRate">胜率，返回结果有该概率为true</param>
	/// <returns></returns>
	public static bool Next(this System.Random random, double successRate)
	{
		return successRate > random.NextDouble();
	}

	/// <summary>
	/// 从序列中随机选择一个元素
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns>失败返回<c>default(T)</c></returns>
	public static T Random<T>(this IList<T> list)
	{
		if (list == null || list.Count == 0)
			return default(T);
		return list[random.Next(list.Count)];
	}
	#endregion

	#region Enumerable
	public static IEnumerable<object> AsEnumerable(this IEnumerator it)
	{
		if (it == null)
			yield break;
		while (it.MoveNext())
			yield return it.Current;
	}

	public static IEnumerable<T> AsEnumerable<T>(this IEnumerator<T> it)
	{
		if (it == null)
			yield break;
		while (it.MoveNext())
			yield return it.Current;
	}

	public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dic, IEnumerable<KeyValuePair<TKey, TValue>> collection)
	{
		foreach (var d in collection)
			dic.Add(d.Key, d.Value);
	}

#if UNITY_METRO && !UNITY_EDITOR
	public static void ForEach<T>(this List<T> list, Action<T> action)
	{
		foreach (var i in list)
			action(i);
	}
#endif
	#endregion

	#region Stream
	public static byte[] ReadAllBytes(this Stream stream)
	{
		int offset = 0;
		int count = (int)stream.Length;
		var buffer = new byte[count];
		while (count > 0)
		{
			int n = stream.Read(buffer, offset, count);
			if (n == 0)
				throw new EndOfStreamException();
			offset += n;
			count -= n;
		}
		return buffer;
	}
	#endregion

	#region Diagnostics
	/// <summary>
	/// 得到所有公有字段的值，用于调试
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public static string ToStringDebug(this object obj)
	{
		return "{ " + string.Join(", ", (
			from f in obj.GetType().GetRuntimeFields()
			select f.Name + "=" + f.GetValue(obj)).ToArray()) + " }";
	}

	public static string ToStringDebug(this ProtoBuf.IExtensible proto)
	{
		var sb = new StringBuilder();
		using(var writer = new StringWriter(sb))
		{
			WriteTo(proto, writer);
		}
		return sb.ToString();
	}

	private static void WriteTo(ProtoBuf.IExtensible proto, TextWriter writer, int indent = 0)
	{
		var prefix = new string(' ', 4 * indent);
		var tab = "    ";
		if (proto == null)
		{
			writer.Write("<null>");
			return;
		}
		writer.Write(proto.GetType().FullName); writer.WriteLine(" {");
		foreach (var p in proto.GetType().GetRuntimeProperties())
		{
			if (p.GetCustomAttributes(typeof(ProtoBuf.ProtoMemberAttribute), false).Any() == false)
				continue;
			writer.Write(prefix); writer.Write(tab); writer.Write(p.Name); writer.Write(" = ");
			var value = p.GetValue(proto, null);
			if (value is ProtoBuf.IExtensible)
			{
				WriteTo((ProtoBuf.IExtensible)value, writer, indent + 1);
			}
			else if (value is IList)
			{
				writer.Write('['); writer.WriteLine();
				foreach (ProtoBuf.IExtensible line in value as IList)
				{
					writer.Write(prefix); writer.Write(tab); writer.Write(tab); WriteTo(line, writer, indent + 2);
					writer.WriteLine();
				}
				writer.Write(prefix); writer.Write(tab); writer.Write(']');
			}
			else if (value is string)
			{
				writer.Write('"'); writer.Write(value); writer.Write('"');
			}
			else
			{
				writer.Write(value);
			}
			writer.WriteLine();
		}
		writer.Write(prefix); writer.Write("}");
	}
	#endregion

	#region Unity
	/// <summary>
	/// Gets or add a component. Usage example:
	/// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
	/// </summary>
	/// <example><code>
	/// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
	/// </code></example>
	/// <remarks> ref: http://wiki.unity3d.com/index.php?title=Singleton </remarks>
	public static T GetOrAddComponent<T>(this Component child) where T : Component
	{
		T result = child.GetComponent<T>();
		if (result == null)
		{
			result = child.gameObject.AddComponent<T>();
		}
		return result;
	}

	class ActionToEnumerator : IEnumerable
	{
		private Action action;
		public ActionToEnumerator(Action action) { this.action = action; }

		#region IEnumerable 成员

		public IEnumerator GetEnumerator()
		{
			if (action == null)
				yield break;
			action();
		}

		#endregion
	}

	public static Coroutine StartCoroutine(this MonoBehaviour mb, Action action)
	{
		return mb.StartCoroutine(new ActionToEnumerator(action).GetEnumerator());
	}

	public static IEnumerable<T> GetComponentsDescendant<T>(this GameObject go) where T : Component
	{
		if (go == null)
			return Enumerable.Empty<T>();
		return GetComponentsDescendant<T>(go.transform);
	}

	public static IEnumerable<T> GetComponentsDescendant<T>(this Component c) where T : Component
	{
		if (c == null)
			return Enumerable.Empty<T>();
		return GetComponentsDescendant<T>(c.transform);
	}

	/// <summary>
	/// ref: http://answers.unity3d.com/questions/555101/possible-to-make-gameobjectgetcomponentinchildren.html
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="transform"></param>
	/// <returns></returns>
	public static IEnumerable<T> GetComponentsDescendant<T>(this Transform transform) where T : Component
	{
		if (transform == null)
			yield break;
		foreach(var c in transform.GetComponents<T>())
			yield return c;

		for(int i = 0; i < transform.childCount; i++)
		{
			foreach(var c in GetComponentsDescendant<T>(transform.GetChild(i)))
				yield return c;
		}
	}

	public static IEnumerable<Transform> GetAllChildren(this Transform transform)
	{
		if (transform == null)
			yield break;
		for (var i = 0; i < transform.childCount; i++)
			yield return transform.GetChild(i);
	}

	/// <summary>
	/// 得到节点全路径
	/// </summary>
	/// <remarks>
	/// ref: http://answers.unity3d.com/questions/8500/how-can-i-get-the-full-path-to-a-gameobject.html
	/// </remarks>
	/// <param name="current"></param>
	/// <returns></returns>
	public static string GetPath(this Transform current)
	{
		if (current.parent == null)
			return "/" + current.name;
		return current.parent.GetPath() + "/" + current.name;
	}
	/// <summary>
	/// 得到节点全路径
	/// </summary>
	/// <param name="component"></param>
	/// <returns></returns>
	public static string GetPath(this Component component)
	{
		return component.transform.GetPath() + "/" + component.GetType().ToString();
	}
	#endregion

	#region Google Protocol Buffers
	/// <summary>
	/// Create a deep clone of the supplied instance; any sub-items are also cloned.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pb"></param>
	/// <returns></returns>
	public static T DeepClone<T>(this T pb) where T : ProtoBuf.IExtensible
	{
		if (pb == null)
			return default(T);
		return ProtoBuf.Serializer.DeepClone<T>(pb);
	}
	#endregion

	#region Convert DateTime & Unix GMT +8
	static readonly DateTime UnixBase = new DateTime(1970, 1, 1, 0, 0, 0);

	/// <summary>
	/// 将本地时区的DateTime时间转换成Unix时戳
	/// </summary>
	/// <param name="time">本地时间</param>
	/// <returns></returns>
	public static uint ToUnixTime(this DateTime time)
	{
		return (uint)(time - UnixBase).TotalSeconds;
	}

	/// <summary>
	/// 将本地时区的Unix时戳转换成DateTime类型
	/// </summary>
	/// <param name="localGMTTime"></param>
	/// <returns></returns>
	public static DateTime ToDateTime(this uint localGMTTime)
	{
		return UnixBase + TimeSpan.FromSeconds(localGMTTime);
	}
	#endregion
}
