//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: PropertyCommand.proto
// Note: requires additional types generated from: Common.proto
// Note: requires additional types generated from: SaveData.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Property")]
  public partial class Property : global::ProtoBuf.IExtensible
  {
    public Property() {}
    
    [global::ProtoBuf.ProtoContract(Name=@"Param")]
    public enum Param
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"AddExpPropertyUserCmd_S", Value=1)]
      AddExpPropertyUserCmd_S = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MainUserDataPropertyUserCmd_S", Value=2)]
      MainUserDataPropertyUserCmd_S = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AddExpPropertyUserCmd_S")]
  public partial class AddExpPropertyUserCmd_S : global::ProtoBuf.IExtensible
  {
    public AddExpPropertyUserCmd_S() {}
    
    private long _curexp;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"curexp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long curexp
    {
      get { return _curexp; }
      set { _curexp = value; }
    }
    private Cmd.ExpType _type;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.ExpType type
    {
      get { return _type; }
      set { _type = value; }
    }
    private long _addexp;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"addexp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long addexp
    {
      get { return _addexp; }
      set { _addexp = value; }
    }
    private long _extexp = default(long);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"extexp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long extexp
    {
      get { return _extexp; }
      set { _extexp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MainUserDataPropertyUserCmd_S")]
  public partial class MainUserDataPropertyUserCmd_S : global::ProtoBuf.IExtensible
  {
    public MainUserDataPropertyUserCmd_S() {}
    
    private Cmd.MainUserData _data;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public Cmd.MainUserData data
    {
      get { return _data; }
      set { _data = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"ExpType")]
    public enum ExpType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"ExpType_None", Value=0)]
      ExpType_None = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ExpType_Levelup", Value=1)]
      ExpType_Levelup = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ExpType_Quest", Value=2)]
      ExpType_Quest = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ExpType_Monster", Value=3)]
      ExpType_Monster = 3
    }
  
}