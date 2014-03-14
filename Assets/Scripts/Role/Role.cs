﻿using UnityEngine;
using System.Collections;
using GX.Net;
using Cmd;
using System.Collections.Generic;

public class Role : MonoBehaviour
{
	public static Dictionary<ulong, Role> All { get; private set; }

	public MapUserData ServerInfo { get; private set; }
	public float speedMainRole = 5.0f;
	private MapNav MapNav { get { return BattleScene.Instance.MapNav; } }

	private Animator animator;


	/// <summary>
	/// 角色世界坐标位置
	/// </summary>
	public Vector3 Position
	{
		get { return this.transform.position; }
		set
		{
			if (MapNav != null)
			{
				value.x = Mathf.Clamp(value.x, 0.5f, MapNav.gridWidth * MapNav.gridXNum - 0.5f);
				value.z = Mathf.Clamp(value.z, 1.0f, MapNav.gridHeight * MapNav.gridZNum - 4.0f);
			}
			this.transform.position = value;
		}
	}

	private Vector3 targetPosition;
	/// <summary>
	/// 设置行走目标点
	/// </summary>
	/// <value>The target position.</value>
	public Vector3 TargetPosition
	{
		get { return targetPosition; }
		set
		{
			if (MapNav != null)
			{
				value.x = Mathf.Clamp(value.x, 0, MapNav.gridWidth * MapNav.gridXNum);
				value.z = Mathf.Clamp(value.z, 0, MapNav.gridHeight * MapNav.gridZNum);
			}
			targetPosition = value;
			if (value != Vector3.zero)
			{
				if (animator.GetFloat("speed") == 0.0f)
					animator.SetFloat("speed", speedMainRole);

				var relativePos = TargetPosition - Position;
				this.transform.rotation = Quaternion.LookRotation(relativePos);
			}
		}
	}

	static Role()
	{
		All = new Dictionary<ulong, Role>();
	}

	private Role() { }

	public static Role Create(MapUserData info)
	{
		var item = table.TableAvatarItem.Select(info.profession, info.sexman);
		var avatar = Avatar.CreateAvatar("Prefabs/Models/Body/Sk_Female_001", item.body, item.head, item.weapon);
		avatar.name = "Role/" + info.charname;
		avatar.transform.localScale = new Vector3(5, 5, 5);
		var role = avatar.AddComponent<Role>();
		role.animator = avatar.GetComponent<Animator>();

		role.ServerInfo = info;
		return role;
	}

	void Update()
	{
		if (TargetPosition != Vector3.zero)
		{
			Vector3 vDelta = TargetPosition - Position;
			float fDeltaLen = vDelta.magnitude;
			vDelta.Normalize();

			Vector3 vOldPosition = Position;
			float fMoveLen = speedMainRole * Time.deltaTime;
			bool bFinish = false;
			if (fMoveLen >= fDeltaLen)
			{
				fMoveLen = fDeltaLen;
				bFinish = true;
			}

			Position = vOldPosition + vDelta * fMoveLen;
			if (bFinish)
			{
				TargetPosition = Vector3.zero;
				var oldRotate = this.transform.rotation;
				animator.SetFloat("speed", 0.0f);
				this.transform.rotation = oldRotate;
			}
		}
	}

	[Execute]
	static void Execute(AddMapUserDataAndPosMapUserCmd_S cmd)
	{
		if (cmd.data.charid == MainRole.ServerInfo.data.charid)
			return;

		Role role;
		if (Role.All.TryGetValue(cmd.data.charid, out role))
		{
			role.ServerInfo = cmd.data;
		}
		else
		{
			role = Role.Create(cmd.data);
			Role.All[cmd.data.charid] = role;
		}

		role.TargetPosition = BattleScene.Instance.MapNav.GetWorldPosition(cmd.pos.x, cmd.pos.y);
	}

	[Execute]
	static void Execute(UserMoveDownMoveUserCmd_S cmd)
	{
		if (cmd.charid == MainRole.ServerInfo.data.charid)
			return;

		Role role;
		if (Role.All.TryGetValue(cmd.charid, out role))
		{
			role.TargetPosition = BattleScene.Instance.MapNav.GetWorldPosition(cmd.pos.x, cmd.pos.y);
		}
	}

	[Execute]
	static void Execute(UserGotoMoveUserCmd_S cmd)
	{
		if (cmd.charid == MainRole.ServerInfo.data.charid)
			return;

		Role role;
		if (Role.All.TryGetValue(cmd.charid, out role))
		{
			role.TargetPosition = BattleScene.Instance.MapNav.GetWorldPosition(cmd.pos.x, cmd.pos.y);
		}
	}
}
