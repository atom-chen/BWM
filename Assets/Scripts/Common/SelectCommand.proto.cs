//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: SelectCommand.proto
// Note: requires additional types generated from: Common.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Select")]
  public partial class Select : global::ProtoBuf.IExtensible
  {
    public Select() {}
    
    [global::ProtoBuf.ProtoContract(Name=@"Param")]
    public enum Param
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"CharactorListRequestSelectUserCmd_C", Value=1)]
      CharactorListRequestSelectUserCmd_C = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CheckCharNameSelectUserCmd_CS", Value=2)]
      CheckCharNameSelectUserCmd_CS = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CharactorListReturnSelectUserCmd_S", Value=3)]
      CharactorListReturnSelectUserCmd_S = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CharactorCreateSelectUserCmd_C", Value=4)]
      CharactorCreateSelectUserCmd_C = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CharactorSelectSelectUserCmd_C", Value=5)]
      CharactorSelectSelectUserCmd_C = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CharactorDeleteSelectUserCmd_C", Value=6)]
      CharactorDeleteSelectUserCmd_C = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CharactorUnregSelectUserCmd_C", Value=7)]
      CharactorUnregSelectUserCmd_C = 7
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharactorListRequestSelectUserCmd_C")]
  public partial class CharactorListRequestSelectUserCmd_C : global::ProtoBuf.IExtensible
  {
    public CharactorListRequestSelectUserCmd_C() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharSelect")]
  public partial class CharSelect : global::ProtoBuf.IExtensible
  {
    public CharSelect() {}
    
    private ulong _charid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"charid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong charid
    {
      get { return _charid; }
      set { _charid = value; }
    }
    private string _charname;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"charname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string charname
    {
      get { return _charname; }
      set { _charname = value; }
    }
    private bool _sexman;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"sexman", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool sexman
    {
      get { return _sexman; }
      set { _sexman = value; }
    }
    private uint _level;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint level
    {
      get { return _level; }
      set { _level = value; }
    }
    private Cmd.Profession _profession;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"profession", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.Profession profession
    {
      get { return _profession; }
      set { _profession = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharactorListReturnSelectUserCmd_S")]
  public partial class CharactorListReturnSelectUserCmd_S : global::ProtoBuf.IExtensible
  {
    public CharactorListReturnSelectUserCmd_S() {}
    
    private readonly global::System.Collections.Generic.List<Cmd.CharSelect> _list = new global::System.Collections.Generic.List<Cmd.CharSelect>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Cmd.CharSelect> list
    {
      get { return _list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckCharNameSelectUserCmd_CS")]
  public partial class CheckCharNameSelectUserCmd_CS : global::ProtoBuf.IExtensible
  {
    public CheckCharNameSelectUserCmd_CS() {}
    
    private string _charname;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"charname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string charname
    {
      get { return _charname; }
      set { _charname = value; }
    }
    private bool _exist = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"exist", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool exist
    {
      get { return _exist; }
      set { _exist = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharactorCreateSelectUserCmd_C")]
  public partial class CharactorCreateSelectUserCmd_C : global::ProtoBuf.IExtensible
  {
    public CharactorCreateSelectUserCmd_C() {}
    
    private string _charname;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"charname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string charname
    {
      get { return _charname; }
      set { _charname = value; }
    }
    private bool _sexman;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"sexman", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool sexman
    {
      get { return _sexman; }
      set { _sexman = value; }
    }
    private Cmd.Profession _profession;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"profession", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Cmd.Profession profession
    {
      get { return _profession; }
      set { _profession = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharactorSelectSelectUserCmd_C")]
  public partial class CharactorSelectSelectUserCmd_C : global::ProtoBuf.IExtensible
  {
    public CharactorSelectSelectUserCmd_C() {}
    
    private ulong _charid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"charid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong charid
    {
      get { return _charid; }
      set { _charid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharactorDeleteSelectUserCmd_C")]
  public partial class CharactorDeleteSelectUserCmd_C : global::ProtoBuf.IExtensible
  {
    public CharactorDeleteSelectUserCmd_C() {}
    
    private ulong _charid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"charid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong charid
    {
      get { return _charid; }
      set { _charid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CharactorUnregSelectUserCmd_C")]
  public partial class CharactorUnregSelectUserCmd_C : global::ProtoBuf.IExtensible
  {
    public CharactorUnregSelectUserCmd_C() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}