unit uDllInterface;

interface
 type
  THotkeyTable = array[0..83] of LongInt;	//每一个数组元素为一条PLU的生鲜码, 		//84个元素对应84条PLU
  PHotkeyTable = ^THotkeyTable;

  //上传PLU及销售流水的回调函数 sResult：流水数据JSON格式 iRecNO:第几条记录 ACount总记录数
 TScaleCallBackProc= procedure(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
   //重量回调
 TWeightCallBackProc = procedure(AWeight:double;  lfcode: Integer); stdcall;

 //更新固件程序的回调函数 sTips：提示信息  status:状态  -1: 连接错误 0:发送升级命令失败  1:正在更新  2:更新错误 3:发送升级结束命令失败  4:升级成功
 //  iRecNO:第几个包  ACount总包数
 TUpgradeFirmwareCallBackProc = procedure(sTips: PAnsiChar; status:Integer; iRecNO: Integer; ACount: Integer); stdcall;

  function rtscaleLoadIniFile(cfgFileName:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';  //加载ini配置文件
  function rtscaleConnect(Addr: PAnsiChar; BaudRate:integer; var Connid:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';
  function rtscaleDisConnect(Connid:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';
  function rtscaleDownLoadData(Connid:Integer; Data:PAnsiChar; len:Integer): Integer; stdcall; far; external 'rtslabelscale.dll'; //下载数据
  function rtscaleUploadData(Connid:Integer; Data:PAnsiChar; len:Integer;  Retdata: PAnsiChar): Integer; stdcall;  far; external 'rtslabelscale.dll'; //上传数据

  function rtscaleClearPLUData(Connid:Integer): Integer; stdcall; far; external 'rtslabelscale.dll'; //清除PLU数据
  function rtscaleDownLoadPLU(Connid:Integer; PluJson:PAnsiChar; ipack:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';   //下载PLU
  function rtscaleDownLoadHotkey(Connid:Integer; HotkeyTable: PHotkeyTable; TableIndex: Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //下载热键
  function rtscaleUploadPluData(Connid:Integer; ACallBac: TScaleCallBackProc): Integer;stdcall;far; external 'rtslabelscale.dll';//上传PLU信息
  function rtscaleUpDatePrice(Connid:Integer; PluPriceJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll'; //更新价格
  function rtscaleClearMessage(Connid:Integer):Integer;far; external 'rtslabelscale.dll'; //清除Message


  function rtscaleDownLoadWeightUnit(Connid:Integer; AWeightUnitJson:PAnsiChar): Integer; stdcall; far; external 'rtslabelscale.dll'; //下载质量单位

  function rtscaleClearPluNutritionData(Connid:Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //清除营养信息的具体数据
  function rtscaleDownLoadNutritionTable(Connid:Integer; sTableJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';//传输营养表 json格式
  function rtscaleDownLoadPluNutrition(Connid:Integer; sNutriDetailJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';//传输每个plu的营养信息4个为一组下发

  function rtscaleDownLoadAdHead(Connid:Integer; AdInfotxt:PAnsiChar; len:Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //下载广告标语的头部信息
  function rtscaleDownLoadAdTail(Connid:Integer; AdInfotxt:PAnsiChar; len:Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //下载广告标语的尾部信息
  function rtscaleUploadDataAdHead(Connid:Integer; Retdata: PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll'; //上传头部数据
  function rtscaleUploadDataAdTail(Connid:Integer; Retdata: PAnsiChar): Integer;stdcall; far; external 'rtslabelscale.dll'; //上传尾部数据

  function rtscaleDownLoadMessage(Connid:Integer; MsgId: Integer; PMessage: PAnsiChar; DataLen: Integer; var iLongMsg:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';
  function rtscaleUploadMessage(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;far; external 'rtslabelscale.dll';//上传Message
  function rtscaleUploadSaleData(Connid:Integer; AIsClear: Boolean; AScaleCallBackProc: TScaleCallBackProc):Integer;stdcall;far; external 'rtslabelscale.dll';//上传销售数据

  function rtscaleDownLoadDisCountSchedule(Connid:Integer; DisCountInfoJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';  //下载折扣信息
  function rtscaleUpLoadDisCountSchedule(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;far; external 'rtslabelscale.dll';  //上传折扣信息
  function rtscaleGetPluWeight(Connid:Integer;  var dWeight: Double): Integer; stdcall;far; external 'rtslabelscale.dll'; //获取重量
  function rtscaleDownLoadCustomBar(Connid:Integer; CusBarJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';  //下载自定义条码

   //升级程序
  function rtscaleUpgradeFirmware(AFileName: PAnsiChar; Addr: PAnsiChar; BaudRate:integer; var Connid:Integer; UpgradeBack: TUpgradeFirmwareCallBackProc):integer;stdcall; far; external 'rtslabelscale.dll';

 function rtscaleDownLoadDepartment(Connid:Integer; depinfoJson:PAnsiChar; isDownGst:Boolean) :integer;stdcall;external 'rtslabelscale.dll';  //下载部门信息
 function rtscaleUpLoadDepartment(Connid:Integer;  ACallBack: TScaleCallBackProc; isUploadGst:Boolean): Integer;stdcall; external 'rtslabelscale.dll';//上传部门信息

 function rtscaleLoadHZCode(isFullCode:Boolean):Boolean;stdcall; external 'rtslabelscale.dll'; //加载简体汉字字库,只要加载一次就可以了
 function rtscaleGetFontCharset(sFontName:PAnsiChar;  var iCharset:Integer):Boolean;stdcall; external 'rtslabelscale.dll';//选择字符集
 function rtscaleCreateFontLib(ParamJson:PAnsiChar;  CallBackProc: TScaleCallBackProc): Integer;stdcall;  external 'rtslabelscale.dll';//创建字库
 function rtscaleGetScaleType(Connid:Integer; sRetJson: PAnsiChar; len:Integer):Integer;stdcall;  external 'rtslabelscale.dll';//查询秤类类型

 function rtscaleCreateCustomFont(AFontName:AnsiString; CallBackProc: TScaleCallBackProc):Boolean;stdcall;external 'rtslabelscale.dll'; //创建固定的加粗字体文件 目前用于泰语版,新西兰语
 function rtscaleDownloadCustomFontFile(Connid:Integer; CallBackProc: TScaleCallBackProc):Boolean; stdcall;  external 'rtslabelscale.dll'; //下载自定义字体

 function rtscaleDownloadExchangeRate(Connid:Integer; rate:integer):Integer;stdcall; external 'rtslabelscale.dll'; //下载汇率
 function rtscaleSetTransBreak(Connid:Integer):Integer;stdcall; external 'rtslabelscale.dll'; //中断传输
 function rtscaleDownLoadVenderPassWord(Connid:Integer; ParamJson: PAnsiChar):Integer; stdcall; external 'rtslabelscale.dll';//下载收银员密码信息
 function rtscaleDownLoadBNPLUExtInfo(Connid:Integer; ParamJson: PAnsiChar; ipackNo:integer):Integer; stdcall; external 'rtslabelscale.dll';//下载宝能PLU扩展信息
 function rtscaleUpLoadBNPLUExtInfo(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//上传宝能PLU扩展信息
 function rtscaleClearBNPLUExtInfo(Connid:Integer):Integer; stdcall;external 'rtslabelscale.dll';//清除PLU附加信息
 function rtscaleDownLoadWEIHAIPLUAddinfo(Connid:Integer; ParamJson: PAnsiChar; ipackNo:integer):Integer; stdcall;external 'rtslabelscale.dll';//下载威海商品附加信息
 function rtscaleUploadWEIHAIPLUAddinfo(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//上传威海商品附加信息
 function rtscaleClearWEIHAIPLUAddinfo(Connid:Integer):Integer; stdcall;external 'rtslabelscale.dll';
 function rtscaleCheckFirmwareVer(Connid:Integer; var ioutVer:Integer): Integer; stdcall;external 'rtslabelscale.dll';
 function rtscaleDownLoadPackTypeFunSet(Connid:Integer; ParamJson: PAnsiChar):Integer; stdcall;external 'rtslabelscale.dll';//下载包装类型设置
 function rtscaleUpLoadPackTypeFunSet(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//上传包装类型编号
 function rtscaleUploadCustomHotkey(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll';///上传自定义功能热键
 function rtscaleDownLoadTraceCode(Connid:Integer; ParamJson: PAnsiChar; ipack:Integer;itype:integer):Integer; stdcall;external 'rtslabelscale.dll'//下载追溯码信息
 function rtscaleDownloadLabelFile(Connid:Integer; AFileName: PAnsiChar;  lblKind:integer; ipaperType:integer):Integer;stdcall; external 'rtslabelscale.dll';//下载标签文件
 function rtscaleDownLoadIM(Connid:Integer; IMFileName: PChar; CallBackProc: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//下载输入法

 function rtscaleStartGetWeightbyNet(wevCallback:TWeightCallBackProc):boolean; stdcall;far; external 'rtslabelscale.dll';//启动获取重量
 function rtscaleStopGetWeightbyNet():boolean; stdcall;far; external 'rtslabelscale.dll';//停止获取重量
 function rtscaleDownLoadMessage_NewSDCard(Connid:Integer; MsgId: Integer; PMessage: PAnsiChar; DataLen: Integer): Integer; stdcall;far; external 'rtslabelscale.dll';//新的Message
 function rtscaleUploadMessage_NewSDCard(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;far; external 'rtslabelscale.dll';//上传新的Message
 function rtscaleDownLoadPluAddinfo_SUPREMA(Connid:Integer; MsgId: Integer; ParamJson: PAnsiChar): Integer; stdcall; external 'rtslabelscale.dll';///下载意大利的附加信息
 function rtscaleUpload_PrnInfo(Connid:Integer; Retdata: PAnsiChar): Integer;stdcall;external 'rtslabelscale.dll';//上传秤的打印信息
 function rtscaleDownLoadRarewords(Connid:Integer;  ACallBack: TScaleCallBackProc): Integer; stdcall;external 'rtslabelscale.dll'; //下载生僻字
 function rtscaleCreateRarewords(ACallBack: TScaleCallBackProc): Integer; stdcall;external 'rtslabelscale.dll'; //创建生僻字
 function rtscaleDownLoadDeletePlu(Connid:Integer; lfCode: Integer): Integer; stdcall;external 'rtslabelscale.dll'; //下载生僻字
 function rtscaleUploadFirmwareVersion(Connid:Integer;Retdata: PAnsiChar): Integer; stdcall; external 'rtslabelscale.dll';

 //AI 专用
 function rtscaleDownLoadAIAddInfo(Connid:Integer; MsgId: Integer; PMessage: PAnsiChar;DataLen: Integer): Integer; stdcall;external 'rtslabelscale.dll'; //下载AI 附加信息
 function rtscaleUploadAIMessage(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll';//上传ai Message
 function rtscaleClearAllAddInfo(Connid:Integer): Integer;stdcall;external 'rtslabelscale.dll'; //清除ai所有附加信息
 function rtscaleDeleteAddInfo(Connid:Integer; Idlist:PAnsiChar): Integer;stdcall;external 'rtslabelscale.dll'; //删除部分附加信息
 function rtscaleDownLoadAIPLUOther(Connid:Integer; ParamJson: PAnsiChar): Integer; stdcall; external 'rtslabelscale.dll';  //下载PLU 其他信息
 function rtscaleDownLoadAITraceCode(Connid:Integer; ParamJson: PAnsiChar): Integer; stdcall;external 'rtslabelscale.dll';  //下载追溯码
 function rtscaleUploadAIAddInfo(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll'; //上传ai Message

 function rtscaleDownLoadActivationCode(Connid:Integer; DeviceNo: PAnsiChar):boolean; stdcall;external 'rtslabelscale.dll';//下载激活码,客户使用
 function rtscaleClearActivationCode(Connid:Integer; DeviceNo: PAnsiChar):boolean; stdcall;external 'rtslabelscale.dll';//激活码清除

 function rtscaleDownLoad_PUPUPLUaddInfo(Connid:Integer; packNo:integer; ParamJson: PAnsiChar): Integer; stdcall;external 'rtslabelscale.dll';//下载朴朴的附加信息
 function rtscaleUpload_PUPUPLUaddInfo(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll';//上传朴朴PLU信息



  implementation





end.
