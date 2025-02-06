unit uDllInterface;

interface
 type
  THotkeyTable = array[0..83] of LongInt;	//ÿһ������Ԫ��Ϊһ��PLU��������, 		//84��Ԫ�ض�Ӧ84��PLU
  PHotkeyTable = ^THotkeyTable;

  //�ϴ�PLU��������ˮ�Ļص����� sResult����ˮ����JSON��ʽ iRecNO:�ڼ�����¼ ACount�ܼ�¼��
 TScaleCallBackProc= procedure(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
   //�����ص�
 TWeightCallBackProc = procedure(AWeight:double;  lfcode: Integer); stdcall;

 //���¹̼�����Ļص����� sTips����ʾ��Ϣ  status:״̬  -1: ���Ӵ��� 0:������������ʧ��  1:���ڸ���  2:���´��� 3:����������������ʧ��  4:�����ɹ�
 //  iRecNO:�ڼ�����  ACount�ܰ���
 TUpgradeFirmwareCallBackProc = procedure(sTips: PAnsiChar; status:Integer; iRecNO: Integer; ACount: Integer); stdcall;

  function rtscaleLoadIniFile(cfgFileName:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';  //����ini�����ļ�
  function rtscaleConnect(Addr: PAnsiChar; BaudRate:integer; var Connid:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';
  function rtscaleDisConnect(Connid:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';
  function rtscaleDownLoadData(Connid:Integer; Data:PAnsiChar; len:Integer): Integer; stdcall; far; external 'rtslabelscale.dll'; //��������
  function rtscaleUploadData(Connid:Integer; Data:PAnsiChar; len:Integer;  Retdata: PAnsiChar): Integer; stdcall;  far; external 'rtslabelscale.dll'; //�ϴ�����

  function rtscaleClearPLUData(Connid:Integer): Integer; stdcall; far; external 'rtslabelscale.dll'; //���PLU����
  function rtscaleDownLoadPLU(Connid:Integer; PluJson:PAnsiChar; ipack:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';   //����PLU
  function rtscaleDownLoadHotkey(Connid:Integer; HotkeyTable: PHotkeyTable; TableIndex: Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //�����ȼ�
  function rtscaleUploadPluData(Connid:Integer; ACallBac: TScaleCallBackProc): Integer;stdcall;far; external 'rtslabelscale.dll';//�ϴ�PLU��Ϣ
  function rtscaleUpDatePrice(Connid:Integer; PluPriceJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll'; //���¼۸�
  function rtscaleClearMessage(Connid:Integer):Integer;far; external 'rtslabelscale.dll'; //���Message


  function rtscaleDownLoadWeightUnit(Connid:Integer; AWeightUnitJson:PAnsiChar): Integer; stdcall; far; external 'rtslabelscale.dll'; //����������λ

  function rtscaleClearPluNutritionData(Connid:Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //���Ӫ����Ϣ�ľ�������
  function rtscaleDownLoadNutritionTable(Connid:Integer; sTableJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';//����Ӫ���� json��ʽ
  function rtscaleDownLoadPluNutrition(Connid:Integer; sNutriDetailJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';//����ÿ��plu��Ӫ����Ϣ4��Ϊһ���·�

  function rtscaleDownLoadAdHead(Connid:Integer; AdInfotxt:PAnsiChar; len:Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //���ع������ͷ����Ϣ
  function rtscaleDownLoadAdTail(Connid:Integer; AdInfotxt:PAnsiChar; len:Integer): Integer; stdcall;far; external 'rtslabelscale.dll'; //���ع������β����Ϣ
  function rtscaleUploadDataAdHead(Connid:Integer; Retdata: PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll'; //�ϴ�ͷ������
  function rtscaleUploadDataAdTail(Connid:Integer; Retdata: PAnsiChar): Integer;stdcall; far; external 'rtslabelscale.dll'; //�ϴ�β������

  function rtscaleDownLoadMessage(Connid:Integer; MsgId: Integer; PMessage: PAnsiChar; DataLen: Integer; var iLongMsg:Integer): Integer; stdcall;far; external 'rtslabelscale.dll';
  function rtscaleUploadMessage(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;far; external 'rtslabelscale.dll';//�ϴ�Message
  function rtscaleUploadSaleData(Connid:Integer; AIsClear: Boolean; AScaleCallBackProc: TScaleCallBackProc):Integer;stdcall;far; external 'rtslabelscale.dll';//�ϴ���������

  function rtscaleDownLoadDisCountSchedule(Connid:Integer; DisCountInfoJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';  //�����ۿ���Ϣ
  function rtscaleUpLoadDisCountSchedule(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;far; external 'rtslabelscale.dll';  //�ϴ��ۿ���Ϣ
  function rtscaleGetPluWeight(Connid:Integer;  var dWeight: Double): Integer; stdcall;far; external 'rtslabelscale.dll'; //��ȡ����
  function rtscaleDownLoadCustomBar(Connid:Integer; CusBarJson:PAnsiChar): Integer; stdcall;far; external 'rtslabelscale.dll';  //�����Զ�������

   //��������
  function rtscaleUpgradeFirmware(AFileName: PAnsiChar; Addr: PAnsiChar; BaudRate:integer; var Connid:Integer; UpgradeBack: TUpgradeFirmwareCallBackProc):integer;stdcall; far; external 'rtslabelscale.dll';

 function rtscaleDownLoadDepartment(Connid:Integer; depinfoJson:PAnsiChar; isDownGst:Boolean) :integer;stdcall;external 'rtslabelscale.dll';  //���ز�����Ϣ
 function rtscaleUpLoadDepartment(Connid:Integer;  ACallBack: TScaleCallBackProc; isUploadGst:Boolean): Integer;stdcall; external 'rtslabelscale.dll';//�ϴ�������Ϣ

 function rtscaleLoadHZCode(isFullCode:Boolean):Boolean;stdcall; external 'rtslabelscale.dll'; //���ؼ��庺���ֿ�,ֻҪ����һ�ξͿ�����
 function rtscaleGetFontCharset(sFontName:PAnsiChar;  var iCharset:Integer):Boolean;stdcall; external 'rtslabelscale.dll';//ѡ���ַ���
 function rtscaleCreateFontLib(ParamJson:PAnsiChar;  CallBackProc: TScaleCallBackProc): Integer;stdcall;  external 'rtslabelscale.dll';//�����ֿ�
 function rtscaleGetScaleType(Connid:Integer; sRetJson: PAnsiChar; len:Integer):Integer;stdcall;  external 'rtslabelscale.dll';//��ѯ��������

 function rtscaleCreateCustomFont(AFontName:AnsiString; CallBackProc: TScaleCallBackProc):Boolean;stdcall;external 'rtslabelscale.dll'; //�����̶��ļӴ������ļ� Ŀǰ����̩���,��������
 function rtscaleDownloadCustomFontFile(Connid:Integer; CallBackProc: TScaleCallBackProc):Boolean; stdcall;  external 'rtslabelscale.dll'; //�����Զ�������

 function rtscaleDownloadExchangeRate(Connid:Integer; rate:integer):Integer;stdcall; external 'rtslabelscale.dll'; //���ػ���
 function rtscaleSetTransBreak(Connid:Integer):Integer;stdcall; external 'rtslabelscale.dll'; //�жϴ���
 function rtscaleDownLoadVenderPassWord(Connid:Integer; ParamJson: PAnsiChar):Integer; stdcall; external 'rtslabelscale.dll';//��������Ա������Ϣ
 function rtscaleDownLoadBNPLUExtInfo(Connid:Integer; ParamJson: PAnsiChar; ipackNo:integer):Integer; stdcall; external 'rtslabelscale.dll';//���ر���PLU��չ��Ϣ
 function rtscaleUpLoadBNPLUExtInfo(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//�ϴ�����PLU��չ��Ϣ
 function rtscaleClearBNPLUExtInfo(Connid:Integer):Integer; stdcall;external 'rtslabelscale.dll';//���PLU������Ϣ
 function rtscaleDownLoadWEIHAIPLUAddinfo(Connid:Integer; ParamJson: PAnsiChar; ipackNo:integer):Integer; stdcall;external 'rtslabelscale.dll';//����������Ʒ������Ϣ
 function rtscaleUploadWEIHAIPLUAddinfo(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//�ϴ�������Ʒ������Ϣ
 function rtscaleClearWEIHAIPLUAddinfo(Connid:Integer):Integer; stdcall;external 'rtslabelscale.dll';
 function rtscaleCheckFirmwareVer(Connid:Integer; var ioutVer:Integer): Integer; stdcall;external 'rtslabelscale.dll';
 function rtscaleDownLoadPackTypeFunSet(Connid:Integer; ParamJson: PAnsiChar):Integer; stdcall;external 'rtslabelscale.dll';//���ذ�װ��������
 function rtscaleUpLoadPackTypeFunSet(Connid:Integer; ACallBack: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//�ϴ���װ���ͱ��
 function rtscaleUploadCustomHotkey(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll';///�ϴ��Զ��幦���ȼ�
 function rtscaleDownLoadTraceCode(Connid:Integer; ParamJson: PAnsiChar; ipack:Integer;itype:integer):Integer; stdcall;external 'rtslabelscale.dll'//����׷������Ϣ
 function rtscaleDownloadLabelFile(Connid:Integer; AFileName: PAnsiChar;  lblKind:integer; ipaperType:integer):Integer;stdcall; external 'rtslabelscale.dll';//���ر�ǩ�ļ�
 function rtscaleDownLoadIM(Connid:Integer; IMFileName: PChar; CallBackProc: TScaleCallBackProc):Integer; stdcall;external 'rtslabelscale.dll';//�������뷨

 function rtscaleStartGetWeightbyNet(wevCallback:TWeightCallBackProc):boolean; stdcall;far; external 'rtslabelscale.dll';//������ȡ����
 function rtscaleStopGetWeightbyNet():boolean; stdcall;far; external 'rtslabelscale.dll';//ֹͣ��ȡ����
 function rtscaleDownLoadMessage_NewSDCard(Connid:Integer; MsgId: Integer; PMessage: PAnsiChar; DataLen: Integer): Integer; stdcall;far; external 'rtslabelscale.dll';//�µ�Message
 function rtscaleUploadMessage_NewSDCard(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;far; external 'rtslabelscale.dll';//�ϴ��µ�Message
 function rtscaleDownLoadPluAddinfo_SUPREMA(Connid:Integer; MsgId: Integer; ParamJson: PAnsiChar): Integer; stdcall; external 'rtslabelscale.dll';///����������ĸ�����Ϣ
 function rtscaleUpload_PrnInfo(Connid:Integer; Retdata: PAnsiChar): Integer;stdcall;external 'rtslabelscale.dll';//�ϴ��ӵĴ�ӡ��Ϣ
 function rtscaleDownLoadRarewords(Connid:Integer;  ACallBack: TScaleCallBackProc): Integer; stdcall;external 'rtslabelscale.dll'; //������Ƨ��
 function rtscaleCreateRarewords(ACallBack: TScaleCallBackProc): Integer; stdcall;external 'rtslabelscale.dll'; //������Ƨ��
 function rtscaleDownLoadDeletePlu(Connid:Integer; lfCode: Integer): Integer; stdcall;external 'rtslabelscale.dll'; //������Ƨ��
 function rtscaleUploadFirmwareVersion(Connid:Integer;Retdata: PAnsiChar): Integer; stdcall; external 'rtslabelscale.dll';

 //AI ר��
 function rtscaleDownLoadAIAddInfo(Connid:Integer; MsgId: Integer; PMessage: PAnsiChar;DataLen: Integer): Integer; stdcall;external 'rtslabelscale.dll'; //����AI ������Ϣ
 function rtscaleUploadAIMessage(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll';//�ϴ�ai Message
 function rtscaleClearAllAddInfo(Connid:Integer): Integer;stdcall;external 'rtslabelscale.dll'; //���ai���и�����Ϣ
 function rtscaleDeleteAddInfo(Connid:Integer; Idlist:PAnsiChar): Integer;stdcall;external 'rtslabelscale.dll'; //ɾ�����ָ�����Ϣ
 function rtscaleDownLoadAIPLUOther(Connid:Integer; ParamJson: PAnsiChar): Integer; stdcall; external 'rtslabelscale.dll';  //����PLU ������Ϣ
 function rtscaleDownLoadAITraceCode(Connid:Integer; ParamJson: PAnsiChar): Integer; stdcall;external 'rtslabelscale.dll';  //����׷����
 function rtscaleUploadAIAddInfo(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll'; //�ϴ�ai Message

 function rtscaleDownLoadActivationCode(Connid:Integer; DeviceNo: PAnsiChar):boolean; stdcall;external 'rtslabelscale.dll';//���ؼ�����,�ͻ�ʹ��
 function rtscaleClearActivationCode(Connid:Integer; DeviceNo: PAnsiChar):boolean; stdcall;external 'rtslabelscale.dll';//���������

 function rtscaleDownLoad_PUPUPLUaddInfo(Connid:Integer; packNo:integer; ParamJson: PAnsiChar): Integer; stdcall;external 'rtslabelscale.dll';//�������ӵĸ�����Ϣ
 function rtscaleUpload_PUPUPLUaddInfo(Connid:Integer; ACallBack: TScaleCallBackProc): Integer;stdcall;external 'rtslabelscale.dll';//�ϴ�����PLU��Ϣ



  implementation





end.
