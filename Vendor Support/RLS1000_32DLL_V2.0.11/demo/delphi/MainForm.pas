unit MainForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,superobject,System.Math,Winapi.ShellAPI, IdBaseComponent,
  IdAntiFreezeBase, IdAntiFreeze,System.IniFiles, Vcl.Samples.Spin, IdComponent,
  IdCustomTCPServer, IdTCPServer, IdTCPConnection, IdTCPClient,idGlobal,
  IdIOHandler, IdIOHandlerStream, IdIOHandlerSocket, IdIOHandlerStack,System.Win.ScktComp,DateUtils;

type

  TFrmMain = class(TForm)
    btnConnect: TButton;
    edtIP: TEdit;
    lblAddr: TLabel;
    btnDownLoadData: TButton;
    btnUploadData: TButton;
    Button1: TButton;
    btnDownLoadPlu: TButton;
    lblDispPrgress: TLabel;
    btnUploadPLU: TButton;
    btnUpdatePrice: TButton;
    btnDownloadNutrition: TButton;
    Label2: TLabel;
    edtNutriName: TEdit;
    btnHead: TButton;
    btnTail: TButton;
    btnUploadSaleData: TButton;
    btnDownloadMsg: TButton;
    btnUpAdHead: TButton;
    btnUpAdTail: TButton;
    Button8: TButton;
    btnDownloadDiscount: TButton;
    btnUploadDiscount: TButton;
    btnWeightUnit: TButton;
    Button13: TButton;
    btnCustomBar: TButton;
    btnUpgradeFirm: TButton;
    OpenDialog1: TOpenDialog;
    Label1: TLabel;
    edtPort: TEdit;
    Label3: TLabel;
    btnDownDept: TButton;
    btnUploadDept: TButton;
    FontDialog1: TFontDialog;
    Button2: TButton;
    cboxFontWeight: TComboBox;
    Label4: TLabel;
    btnCharset: TButton;
    edtFontCharset: TEdit;
    btnCreateBoldFnt: TButton;
    downloadCustomFont: TButton;
    btnDownloadExchangeRate: TButton;
    btnSetTransBreak: TButton;
    Button3: TButton;
    Button6: TButton;
    Button12: TButton;
    Button14: TButton;
    btnUploadCustomHotkey: TButton;
    Button15: TButton;
    btnGenOtherFnt: TButton;
    btnDownloadOtherFnt: TButton;
    Button19: TButton;
    IdTCPClient1: TIdTCPClient;
    IdIOHandlerStack1: TIdIOHandlerStack;
    Button28: TButton;
    edtPlu: TEdit;
    Button29: TButton;
    Button4: TButton;
    procedure btnConnectClick(Sender: TObject);
    procedure btnDownLoadDataClick(Sender: TObject);
    procedure btnUploadDataClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure btnDownLoadPluClick(Sender: TObject);
    procedure btnUploadPLUClick(Sender: TObject);
    procedure btnUpdatePriceClick(Sender: TObject);
    procedure btnDownloadNutritionClick(Sender: TObject);
    procedure Button13Click(Sender: TObject);
    procedure btnDownloadMsgClick(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure btnWeightUnitClick(Sender: TObject);
    procedure btnHeadClick(Sender: TObject);
    procedure btnTailClick(Sender: TObject);
    procedure btnUpAdHeadClick(Sender: TObject);
    procedure btnUpAdTailClick(Sender: TObject);
    procedure btnUploadSaleDataClick(Sender: TObject);
    procedure btnDownloadDiscountClick(Sender: TObject);
    procedure btnUploadDiscountClick(Sender: TObject);
    procedure btnCustomBarClick(Sender: TObject);
    procedure btnUpgradeFirmClick(Sender: TObject);
    procedure edtIPKeyPress(Sender: TObject; var Key: Char);
    procedure edtPortKeyPress(Sender: TObject; var Key: Char);
    procedure btnDownDeptClick(Sender: TObject);
    procedure btnUploadDeptClick(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure btnCharsetClick(Sender: TObject);
    procedure btnCreateBoldFntClick(Sender: TObject);
    procedure downloadCustomFontClick(Sender: TObject);
    procedure btnDownloadExchangeRateClick(Sender: TObject);
    procedure btnSetTransBreakClick(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button14Click(Sender: TObject);
    procedure btnUploadCustomHotkeyClick(Sender: TObject);
    procedure Button15Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnGenOtherFntClick(Sender: TObject);
    procedure btnDownloadOtherFntClick(Sender: TObject);
    procedure Button19Click(Sender: TObject);
    procedure Button28Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);

  private
    Connid:Integer;
    function ConnectScale:Boolean;
    function DownLoadHotKey:Integer;
    function DownLoadPlu:Boolean;
    function DownLoadNutritionTable: Boolean; //下载营养表
    function DownLoadPluNutrition: Boolean; //下载单品的营养信息
    { Private declarations }
  public
    procedure ShowStatus(s:String);
    { Public declarations }
  end;

procedure CreateFntFileCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
procedure DownloadFntFileCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;

var
  FrmMain: TFrmMain;

implementation
uses
  uDllInterface, uGlobalFun, addInfoForm;
//  uGlobalFun,uScaleDllExport,uGlobal,uRt1Protocol,uRt2Protocol, addInfoForm,uConfig,uRtUdpServer,
//  otherForm;


{$R *.dfm}




procedure TFrmMain.btnCharsetClick(Sender: TObject);
var
  iCharset:Integer;
  s:string;
begin
  iCharset := StrToInt(edtFontCharset.Text);
  s := FontDialog1.Font.Name;
  if rtscaleGetFontCharset(PAnsiChar(AnsiString(s)),iCharset) then
  begin
    edtFontCharset.Text := IntToStr(iCharset);
  end
end;

procedure TFrmMain.btnConnectClick(Sender: TObject);
var
  sRetJson:AnsiString;
  jo:ISuperObject;
  iRet:Integer;
  fileName:AnsiString;
  inifile:Tinifile;
begin
 fileName :=ExtractFilePath(Application.ExeName)+ '.\SYSTEM.CFG';
 rtscaleLoadIniFile(PAnsiChar(fileName));//加载配置文件
 inifile := Tinifile.Create(fileName);
 if inifile.ReadInteger('Function','WeightRatio_500g',1)=1000 then
   FormatStr[7] := '%6.3f';//yuntan
  if ConnectScale then
  begin
   SetLength(sRetJson,100);
   iRet := rtscaleGetScaleType(Connid,PAnsiChar(sRetJson),Length(sRetJson));
   rtscaleDisConnect(Connid);
   if iRet=0 then  //获取秤类型
   begin
     jo := SO(sRetJson);
     ShowMessage(Format('Protocol=%d',[jo.I['Protocol']]));
   end;
   ShowMessage('connect ok');
  end
  else
  begin
    ShowMessage('connect Fail');
     rtscaleDisConnect(Connid);
  end;
end;


procedure TFrmMain.btnDownLoadDataClick(Sender: TObject);
var
  ret:Integer;
  Data:TData;
  sRetJson:AnsiString;
  jo:ISuperObject;
  iProtocol,iSendLen:Integer;
begin
  ret := -1;
  if ConnectScale then
  begin
    try
      SetLength(sRetJson,100);
      iProtocol := 0;
      if rtscaleGetScaleType(Connid,PAnsiChar(sRetJson),Length(sRetJson))=0 then  //获取秤类型
       begin
         jo := SO(sRetJson);
         iProtocol := jo.I['Protocol'];
       end;
      if iProtocol=1 then
       iSendLen := 265
      else
       iSendLen := 261;
      Data := GetSendTestData(iProtocol);
      ret := rtscaleDownLoadData(Connid, @Data,iSendLen);
    finally
    //  rtscaleDisConnect(Connid);
      ShowMessage(IntToStr(Ret));
    end;


  end else
    ShowMessage('connect Fail');


end;

procedure TFrmMain.btnUpdatePriceClick(Sender: TObject);
var
  ret,i,J:Integer;
  Data:TData;
  jo,aSuperArray: ISuperObject;
  sjson:Ansistring;
begin
  if ConnectScale then
  begin
    for J := 0 to 10 do
    begin
      aSuperArray := SA([]);

      for i:=0 to 28 do  //一次只能传36条  香港版本的，只有25
      begin
        jo := SO();
        jo.I['LFCode'] :=  J * 28 + I + 1;// + 10000; //生鲜码,1-999999,唯一识别每一种生鲜商品 fresh code, 1-999999, uniquely identifies each fresh product
        jo.I['UnitPrice'] :=10; //(J * 36 + I + 1)*100;//单价,无小数模式,0-9999999    unit price, no decimal mode, 0-9999999
        aSuperArray.AsArray.Add(jo);
      end;
     //Transfer one PLU
     ShowStatus(IntToStr((J+1) * 4));

     sjson := aSuperArray.AsJSon(True,False);

//    ShowMessage(sjson);
     aSuperArray := nil;
     ret := rtscaleUpDatePrice(Connid,PAnsiChar(sjson));
     rtscaleDisConnect(Connid);
     if (ret = 0) then
       ShowMessage('ok')
     else
     begin
       rtscaleDisConnect(Connid);
       Exit;
     end;

    end;

  end else
    ShowMessage('connect Fail');


  //
end;

procedure TFrmMain.btnUploadDataClick(Sender: TObject);
var
  ret:Integer;
  Data:TData;
  retData:TData;
  Str,sRetJson:Ansistring;
  iProtocol:Integer;
  jo:ISuperObject;
  iSendLen:Integer;
  i:Integer;
begin
  if ConnectScale then
  begin
    try
      SetLength(sRetJson,100);
      iProtocol := 0;
      if rtscaleGetScaleType(Connid,PAnsiChar(sRetJson),Length(sRetJson))=0 then  //获取秤类型
      begin
        jo := SO(sRetJson);
        iProtocol := jo.I['Protocol'];
      end;
      Data := getUploadTestData(iProtocol);
      FillChar(retData,SizeOf(retData),0);
      if iProtocol=1 then
       iSendLen := 265
      else
       iSendLen := 261;
       ret := rtscaleUploadData(Connid, @Data,iSendLen,@retData); //retData=265byte use 256
    finally
      rtscaleDisConnect(Connid);
      if (ret=0) then
      begin
        Str:='';
        for i:=0 to iSendLen-1 do
        begin
          Str:=Str+format('%2.2x ',[retData[i]]);
          if(i mod 16 =15)then
          begin
            Str := Str+#13#10;
          end;
        end;
        ShowMessage(Str);
      end;

    end;

//    SetLength(S, 6);
//    AnsiMemCopy(@S[1], @retData[7], 6);

  end else
  begin
    ShowMessage('connect Fail');
    exit;
  end;

end;




procedure  UpLoadDepartmentCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer);stdcall;
var
  i,j,iLen: Integer;
  FileName: string;
  jo: ISuperObject;
  ObjAry:TSuperArray;
  s: Ansistring;
  F1: TextFile;
begin
  jo :=SO(sResult);
  ObjAry := jo.AsArray;
  FileName := ExtractFilePath(Application.ExeName)+'DepartMent.txt';

  AssignFile(F1, FileName);
  try
    Rewrite(F1);
    jo := SO(sResult);
    ObjAry := jo.AsArray;
    for I := 0 to ObjAry.Length-1 do
    begin
      s :=  IntToStr(ObjAry[i].I['DeptId'])+#9+ ObjAry[i].S['DeptName']+#9 + BoolToStr(ObjAry[i].B['IsPrintDeptId'],True)+#9
          + BoolToStr(ObjAry[i].B['IsPrintDeptName'],True)+#9 +FormatFloat('0.00', ObjAry[i].D['SGST'])+#9
          +FormatFloat('0.00', ObjAry[i].D['CGST']);
      writeln(F1,s);
    end;

  finally
    CloseFile(F1);
  end;

end;

procedure TFrmMain.btnUploadDeptClick(Sender: TObject);
var
  FileName:string;
  iRet:Integer;
begin
  FileName := ExtractFilePath(Application.ExeName)+'DepartMent.txt';
  if not ConnectScale then
  begin
    ShowMessage('connect Fail');
    exit;
  end;

  iRet :=rtscaleUpLoadDepartment(Connid,UpLoadDepartmentCallback,True);
  rtscaleDisConnect(Connid);
  if iRet>0 then
  begin
    ShellExecute(0, 'open', PChar(FileName), nil, nil, SW_SHOWNORMAL);
  end else if iRet=0 then
    ShowMessage('no data')
  else
    ShowMessage('upload error');

end;

procedure TFrmMain.btnWeightUnitClick(Sender: TObject);
const
  AryWeightUnit:array[0..14] of AnsiString=('50g','g','10g','100g','Kg','Oz','LB','500g','600g','pcs(g)','pcs(kg)','pcs(oz)','pcs(Lb)','','');
 // AryWeightUnit:array[0..14] of AnsiString=('pcs(1)','pcs(2)','pcs(3)','pcs(4)','pcs(5)','pcs(6)','pcs(7)','pcs(8)','pcs(9)','pcs(10)','pcs(11)','pcs(12)','pcs(13)','pcs(14)','pcs(15)');
var
  ret:Integer;
  S:Ansistring;
  jo: ISuperObject;
  i:Integer;
begin
  if ConnectScale then
  begin
    jo := SO();
    //WeightUnit0-WeightUnit8重量单位, WeightUnit9-WeightUnit23 为数量单位（1~15），WeightUnit24: 元
    for i := 0 to 14 do
      jo.S['WeightUnit'+IntToStr(i)] := AryWeightUnit[i];
    jo.S['WeightUnit4'] := '公斤';
    for i := 15 to 23 do   //
      jo.S['WeightUnit'+IntToStr(i)] := '';

     jo.S['WeightUnit24'] := '元';
    s := jo.AsJSon(True,False);
    ret := rtscaleDownLoadWeightUnit(Connid,PAnsiChar(s));
    rtscaleDisConnect(Connid);
    if ret=0 then
      ShowMessage('ok');

  end else
  begin
    ShowMessage('connect Fail');
    exit;
  end;




end;

procedure TFrmMain.btnDownloadDiscountClick(Sender: TObject);
var
  i,j,iret: Integer;
  s: Ansistring;
  jo,aSuperArray: ISuperObject;
begin
  if  ConnectScale then
  begin
    aSuperArray := SA([]);
    for i := 1 to 10 do  //一个模式5个时段，10个模式，最多50个时段
    begin
      for j := 1 to 5  do
      begin
        jo := SO();
        jo.I['Hour'] := j+8;
        jo.I['Minute'] := 30;//该值，要能整除10
        jo.I['Discount'] := 100-20;//打8折
        aSuperArray.AsArray.Add(jo);
      end;
    end;
    s := aSuperArray.AsJSon(True,False);
    iret := rtscaleDownLoadDisCountSchedule(Connid,PAnsiChar(s));
    rtscaleDisConnect(Connid);
    if iret=0 then
       ShowMessage('OK')
    else
       ShowMessage('Fail');
    aSuperArray := nil;

  end else
     ShowMessage('connect Fail');

end;


procedure TFrmMain.btnDownloadExchangeRateClick(Sender: TObject);
var
  iRet:Integer;
begin
  if ConnectScale then
  begin
    iRet :=rtscaleDownloadExchangeRate(Connid,300); //最多8位
    rtscaleDisConnect(Connid);
    if iRet=0 then
      ShowMessage('ok')
    else
      ShowMessage('Fail');

  end;
// rtscaleDownloadExchangeRate(Connid,123456);
end;

procedure UploadDiscountCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  i,j,iLen: Integer;
  sRetJson: PAnsiChar;
  jo: ISuperObject;
  ObjAry:TSuperArray;
  s:string;
  iHour,iMinute,iDiscount:Integer;
begin
  jo :=SO(sResult);
   ObjAry := jo.AsArray;
  for i := 0 to ObjAry.Length div 10 -1  do  //一个模式5个时段，10个模式，100个时段
  begin
    for j := 0 to 5-1 do
    begin
      iHour := ObjAry[i*5+j].I['Hour'];
      iMinute := ObjAry[i*5+j].I['Minute'];
      iDiscount := ObjAry[i*5+j].I['Discount'];
      s := s + Format('mode%d Hour:%d Minute:%d  Discount:%d',[i+1,iHour,iMinute,100-iDiscount])+#13#10;
    end;
  end;
  ShowMessage(s);
end;

procedure TFrmMain.btnUploadDiscountClick(Sender: TObject);
var
  iret:Integer;
begin
  if  ConnectScale then
  begin
    iret := rtscaleUpLoadDisCountSchedule(Connid,UploadDiscountCallback);
    rtscaleDisConnect(Connid);
    if iret=0 then
     // showMessage('ok')
    else
      showMessage('Fail');
 end else
     ShowMessage('connect Fail');

end;



procedure TFrmMain.Button11Click(Sender: TObject);
begin
end;

//下载包装类型
procedure TFrmMain.Button12Click(Sender: TObject);
var
  ret,i,J:Integer;
  Data:TData;
  jo,aSuperArray: ISuperObject;
  sjson:Ansistring;
begin
  if ConnectScale then
  begin
    aSuperArray := SA([]);
    for i:=1 to 14 do  //只能传14条
    begin
      jo := SO();
      jo.S['KeyValue'] :='1'+IntTostr(i)+'0';//
      aSuperArray.AsArray.Add(jo);
    end;
    sjson := aSuperArray.AsJSon(True,False);
   // ShowMessage(sjson);
     aSuperArray := nil;
     ret := rtscaleDownLoadPackTypeFunSet(Connid,PAnsiChar(sjson));
     rtscaleDisConnect(Connid);
     if (ret = 0) then
       ShowMessage('ok')
     else
     begin
       rtscaleDisConnect(Connid);
       Exit;
     end;
  end;




end;

procedure TFrmMain.Button13Click(Sender: TObject);
var
  dWeight: Double;
  iRet:Integer;
begin
  if  ConnectScale then
  begin
    iRet := rtscaleGetPluWeight(connid,dWeight);
    rtscaleDisConnect(Connid);
    if iRet=0 then
    begin
      ShowMessage('Current weight: '+FloatToStr(dWeight));
    end else
    begin
     ShowMessage('get weight Fail'+IntToStr(iRet));
    end;

  end else
    ShowMessage('connect Fail');
end;

procedure UploadPacktypeCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  i: Integer;
  sRetJson: PAnsiChar;
  jo: ISuperObject;
  ObjAry:TSuperArray;
  s:Ansistring;
begin
  jo :=SO(sResult);
  ObjAry := jo.AsArray;
  s := '';
  for i := 0 to ObjAry.Length -1  do  //一个模式5个时段，10个模式，100个时段
  begin
    s  := s + ObjAry[i].S['KeyValue']+#13#10;
  end;
  ShowMessage(s);
end;

//上传包装类型
procedure TFrmMain.Button14Click(Sender: TObject);
var
  iret:Integer;
begin
  if  ConnectScale then
  begin
    iret := rtscaleUpLoadPackTypeFunSet(Connid,UploadPacktypeCallback);
    rtscaleDisConnect(Connid);
    if iret=0 then
     // showMessage('ok')
    else
      showMessage('Fail');
 end else
     ShowMessage('connect Fail')
end;



procedure DonwloadPYCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
begin
  FrmMain.ShowStatus( Format('dowload IM %d/%d',[iRecNO,ACount]));
  //ShowMessage(s);
end;


procedure TFrmMain.Button15Click(Sender: TObject);
var
  fileName:String;
  iRtn: integer;
  s: AnsiString;
begin
  if ConnectScale then
  begin
    fileName := ExtractFilePath(Application.ExeName)+'IMPY.bin';
    iRtn := rtscaleDownLoadIM(Connid,PChar(fileName), DonwloadPYCallback);
    rtscaleDisConnect(Connid);
    if iRtn=0 then
      showMessage('ok')
    else if iRtn=-2 then
       showMessage('file not exists')
    else
      ShowMessage('Fail');

  end;

end;




procedure TFrmMain.Button19Click(Sender: TObject);
var
  sRet:AnsiString;
  iret:integer;
begin
  if ConnectScale then
  begin
    SetLength(sRet,256);
    iret := rtscaleUpload_PrnInfo(Connid,PAnsiChar(sRet));

    rtscaleDisConnect(Connid);
    if iret=0 then
      ShowMessage(sRet)
    else
      ShowMessage('Fail');

  end;
end;

procedure TFrmMain.Button1Click(Sender: TObject);
var
  iRet:Integer;
begin
  if ConnectScale then
  begin
 //   sleep(1000);
    iRet :=rtscaleClearPLUData(Connid);
    rtscaleDisConnect(Connid);
    if iRet=0 then
      ShowMessage('Clear plu ok')
    else
      ShowMessage('Clear plu Fail');

  end;
end;




procedure MyUpgradeFirmwareCallBack(sTips: PAnsiChar; status:Integer; iRecNO: Integer; ACount: Integer);stdcall;
var
  s:string;
begin
  case status of
    Upgrade_Status_upgrading,
    Upgrade_Status_upgradeFail,
    Upgrade_Status_upgradeOk:
      s := strpas(sTips)+Format('%d/%d',[iRecNO,ACount])
  else
     s := sTips;
  end;
  FrmMain.ShowStatus(s);
end;

procedure TFrmMain.btnUpgradeFirmClick(Sender: TObject);
var
  iRet:Integer;
  sFileName:AnsiString;
  sIp:AnsiString;
begin
  OpenDialog1.Filter := 'Binary Files|*.hex|All Files|*.*';
  if OpenDialog1.Execute then
  begin
    sFileName := OpenDialog1.FileName;
    sIp := edtIP.Text;
    iRet := rtscaleUpgradeFirmware(PAnsiChar(sFileName), PAnsiChar(sIp),StrToInt(edtPort.Text), Connid,MyUpgradeFirmwareCallBack);
    if iRet=0 then
      showMessage('ok')
    else
      showMessage('Fail')
  end;

end;

procedure TFrmMain.btnCustomBarClick(Sender: TObject);
var
  jo,aSuperArray: ISuperObject;
  s:Ansistring;
  I:Integer;
  iRet:Integer;
begin

  if ConnectScale then
  begin
    aSuperArray := SA([]);

    jo := SO();
//    jo.I['BarID'] := 101;
//    jo.S['BarFormat'] :='23LLLLLPPPPPWWWWWC';  // 'DDLLLLLUUUUUC';
//    jo.I['BarKind'] := 18; //条码类型(长度) Barcode type (length)
//    jo.I['OffsetLen'] := 3; //Decimal places for weight or quantity
//    aSuperArray.AsArray.Add(jo);
//    jo := SO();
//    jo.I['BarID'] := 102;
//    jo.S['BarFormat'] :='23LLLLLPPPPPWWWWWC';  // 'DDLLLLLUUUUUC';
//    jo.I['BarKind'] := 18; //条码类型(长度) Barcode type (length)
//    jo.I['OffsetLen'] := 3; //Decimal places for weight or quantity
//    aSuperArray.AsArray.Add(jo);


    for I := 101 to 118 do
    begin
      jo := SO();
      jo.I['BarID'] := I;
      jo.S['BarFormat'] :='DDLLLLLUUUUUC';  // 'DDLLLLLUUUUUC';
      jo.I['BarKind'] := 0; //条码类型(长度) Barcode type (length)
      jo.I['OffsetLen'] := 0; //Decimal places for weight or quantity
//      if I=101 then
//      begin
//        jo.I['BarID'] := 101;
//        jo.S['BarFormat'] :='[HW]26IIIIIIIIIIC';  // 'DDLLLLLUUUUUC';
//        jo.I['BarKind'] := 13; //条码类型(长度) Barcode type (length)
//        jo.I['OffsetLen'] := 0; //Decimal places for weight or quantity
//      end;
//
//      if I=102 then
//      begin
//        jo.I['BarID'] := 102;
//        jo.S['BarFormat'] :='26IIIIIIPPPPPWWWWWC';  // 'DDLLLLLUUUUUC';
//        jo.I['BarKind'] := 19; //条码类型(长度) Barcode type (length)
//        jo.I['OffsetLen'] := 0; //Decimal places for weight or quantity
//      end;

       if I=112 then
       begin
         jo.I['BarID'] := 112;
         jo.S['BarFormat'] :='26IIIIIIPPPPPWWWWWC';  // 'DDLLLLLUUUUUC';
         jo.I['BarKind'] := 19; //条码类型(长度) Barcode type (length)
         jo.I['OffsetLen'] := 2; //Decimal places for weight or quantity
       end;



      aSuperArray.AsArray.Add(jo);
//      jo := SO();
//      jo.I['BarID'] := 102;
//      jo.S['BarFormat'] := '18LLLLLWWWWWPPPPPC';
//      jo.I['BarKind'] := 18; //条码类型(长度) Barcode type (length)
//      jo.I['OffsetLen'] := 3; //重量或数量的小数位  Decimal places for weight or quantity

    end;


//    jo.I['BarID'] :=  111;
//    jo.S['BarFormat'] :='123483EIII';  // 'DDLLLLLUUUUUC';
//    jo.I['BarKind'] := 18; //条码类型(长度) Barcode type (length)
//    jo.I['OffsetLen'] := 3; //Decimal places for weight or quantity
//    aSuperArray.AsArray.Add(jo);
//
//
//    jo.I['BarID'] :=  1112;
//    jo.S['BarFormat'] :='123483FIII';  // 'DDLLLLLUUUUUC';
//    jo.I['BarKind'] := 18; //条码类型(长度) Barcode type (length)
//    jo.I['OffsetLen'] := 3; //Decimal places for weight or quantity
//    aSuperArray.AsArray.Add(jo);
//    for J := 101 to 110 do
//    begin
//      jo := SO();
//      jo.I['BarID'] := j;
//      jo.S['BarFormat'] := 'DDLLLLLUUUUUC';
//      jo.I['BarKind'] := 13; //条码类型(长度) Barcode type (length)
//      jo.I['OffsetLen'] := 2; //重量或数量的小数位  Decimal places for weight or quantity
//      aSuperArray.AsArray.Add(jo);
//    end;
    S := aSuperArray.AsJSon(True,False);
//    iRet := rtscaleGenCustomBarBin(Connid,PAnsichar(s),'mybar.bin');
    iRet := rtscaleDownLoadCustomBar(Connid,PAnsichar(s));
    rtscaleDisConnect(Connid);
    if iRet=0 then
      showMessage('ok')
    else
      ShowMessage('Fail');
  end
  else
    ShowMessage('connect Fail');



end;

function getColumnHead(): string; //列头
begin
  Result := '';
  Result := Result + AligSpaceStr('User',7);
  Result := Result + #9 + AligSpaceStr('LFCode',7);
  Result := Result + #9 + AligSpaceStr('PluName',20);
  Result := Result + #9 + AligSpaceStr('UtPric',10,taRight);
  Result := Result + #9 + AligSpaceStr('WeiUt',8);
  Result := Result + #9 + AligSpaceStr('TotPric',10,taRight);
  Result := Result + #9 + AligSpaceStr('Weight',10,taRight);
  Result := Result + #9 + AligSpaceStr('SaleTime',14);
  Result := Result + #9 + AligSpaceStr('Rebate',6);
  Result := Result + #9 + AligSpaceStr('LineTime',14);
  Result := Result + #9 + AligSpaceStr('Quantity',5,taRight);
end;

function AccountToStr(Account: TScaleAccount): AnsiString;
const
  prec=2; //Decimal digits 小数点位数
begin
  Result := '';
  Result := Result + AligSpaceStr(IntToStr(Account.UserID),7);
  Result := Result + #9 + AligSpaceStr(IntToStr(Account.LFCode),7);
  Result := Result + #9 + AligSpaceStr(Trim(StrPas(Account.PluName)),20);
  Result := Result + #9 + AligSpaceStr(Format('%.*f', [prec, Account.UnitPrice]),10,taRight);
  Result := Result + #9 + AligSpaceStr(C_WeightUnit[Account.WeightUnit],8,taLeft);    //IntToHex(Account.WeightUnit, 1);
  Result := Result + #9 + AligSpaceStr(Format('%.*f', [prec, Account.TotalPrice]),10,taRight);
  if (Account.WeightUnit < 9) then
    Result := Result + #9 + AligSpaceStr(Format(FormatStr[Account.WeightUnit], [Account.Weight]),10,taRight)
  else
    Result := Result + #9 + AligSpaceStr(Format('%.0f', [Account.Weight]),10,taRight);
  if Account.SaleTime=0 then
    Result := Result + #9 +  ''
  else
    Result := Result + #9 +   FormatDateTime('yyyymmddhhnnss', Account.SaleTime);
  Result := Result + #9 + AligSpaceStr(IntToStr(Account.Rebate),6,taRight);
  Result := Result + #9 + FormatDateTime('yyyymmddhhnnss', Account.OnlineTime);
  Result := Result + #9 + AligSpaceStr(IntToStr(Account.Quantity),5,taRight);
  Result := Result + #9 + AligSpaceStr(IntToStr(Account.SerialNum),5,taRight);
end;

procedure UploadSaleDataBack(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  ScaleAccount:TScaleAccount;
  I:Integer;
  F1: TextFile;
  FileName:string;
  jo: ISuperObject;
  s:Ansistring;
begin
  FileName := ExtractFilePath(Application.ExeName)+'salelist.txt';
  FrmMain.ShowStatus(Format('%d/%d',[iRecNO,ACount]));
  AssignFile(F1, FileName);
  try
    if iRecNO=1 then // if (not FileExists(FileName)) then
    begin
      Rewrite(F1);
      writeln(F1, getColumnHead()); //填写流水帐的标题
    end
    else
    begin
      Append(F1);
    end;
    jo := SO(sResult);
   // ShowMessage(jo.AsJSon(True,False));
    FillChar(ScaleAccount,SizeOf(TScaleAccount),#0);
    ScaleAccount.UserID :=jo.I['UserID'];
    ScaleAccount.UserId := ScaleAccount.UserID;
    s := RTrim(jo.S['PluName'],#$FF);
    StrLCopy(ScaleAccount.PluName,PAnsiChar(s),Length(s));
    ScaleAccount.LFCode := jo.I['LFCode'];
    ScaleAccount.UnitPrice := jo.D['UnitPrice'];
    ScaleAccount.WeightUnit := jo.I['WeightUnit']; //单位
    ScaleAccount.TotalPrice := jo.D['TotalPrice']; //总价
    ScaleAccount.Weight := jo.D['Weight']; //重量
    ScaleAccount.SaleTime   := YMDHMSToDateTime(jo.S['SaleTime']); //销售时间
    ScaleAccount.Rebate := jo.I['Rebate']; //折扣
    ScaleAccount.OnlineTime := YMDHMSToDateTime(jo.S['OnlineTime']); //上次清除流水的时间
    ScaleAccount.Quantity := jo.I['Quantity']; //折扣
    ScaleAccount.Clerk := jo.I['Clerk']; //折扣
    ScaleAccount.SerialNum := jo.I['SerialNum'];
//    if (Trim(s)<>'') and (Ord(s[1])<>$FF) then
      writeln(F1, AccountToStr(ScaleAccount));
  finally
    CloseFile(F1);
   //ush(F1);
  end;

end;





procedure TFrmMain.btnUploadSaleDataClick(Sender: TObject);
var
  iRtn: integer;
  FileName:string;
begin
  if ConnectScale then
  begin
    iRtn := rtscaleUploadSaleData(Connid,true,UploadSaleDataBack);//上传销售数据
    rtscaleDisConnect(Connid);
    if iRtn>=0 then
    begin
      FileName := ExtractFilePath(Application.ExeName)+'salelist.txt';
      ShowMessageFmt('Number of records:%d',[iRtn]);
      ShellExecute(0, 'open', PChar(FileName), nil, nil, SW_SHOWNORMAL);
    end
    else
      ShowMessage('Fail');

  end;
end;

procedure TFrmMain.btnUpAdTailClick(Sender: TObject);
var
  iRtn: integer;
  s: AnsiString;
begin
  if ConnectScale then
  begin
    SetLength(s,256);
    iRtn := rtscaleUploadDataAdTail(Connid,PAnsiChar(s));
    rtscaleDisConnect(Connid);
    if iRtn=0 then
      showMessage(TrimRight(s))
    else
      ShowMessage('Fail');

  end;
end;

procedure TFrmMain.btnUpAdHeadClick(Sender: TObject);
var
  iRtn: integer;
  s: AnsiString;
begin
  if ConnectScale then
  begin
    SetLength(s,256);
    iRtn := rtscaleUploadDataAdHead(Connid,PAnsiChar(s));
    rtscaleDisConnect(Connid);
    if iRtn=0 then
      showMessage(TrimRight(s))
    else
      ShowMessage('Fail');

  end;
end;

procedure TFrmMain.btnTailClick(Sender: TObject);
var
  iRtn: integer;
  s: AnsiString;
begin
  if ConnectScale then
  begin
    s := 'this is Tail1'+#13#10+'this is Tail2'+#13#10+'this is Tail3';
    iRtn := rtscaleDownLoadAdTail(Connid,PAnsiChar(s),Length(s));
    rtscaleDisConnect(Connid);
    if iRtn=0 then
      showMessage('ok')
    else
      ShowMessage('Fail');

  end;

end;

procedure TFrmMain.btnHeadClick(Sender: TObject);
var
  iRtn: integer;
  s: AnsiString;
begin
  if ConnectScale then
  begin
    s := 'Welcome to RLS1000';
    iRtn := rtscaleDownLoadAdHead(Connid,PAnsiChar(s),Length(s));
    rtscaleDisConnect(Connid);
    if iRtn=0 then
      showMessage('ok')
    else
      ShowMessage('Fail');

  end;
end;


//
procedure UploadMsgback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  Filename:string;
  F1: TextFile;
  jo: ISuperObject;
  s,sValue:AnsiString;
  sList:TStringList;
  i:Integer;
  MsgId:integer;
begin
  Filename := ExtractFilePath(Application.ExeName)+'Msg.txt';
  FrmMain.ShowStatus(Format('%d',[iRecNO]));

  AssignFile(F1, FileName);
  sList := TStringList.Create;
  try
    if (iRecNO=1) or (not FileExists(Filename)) then
    begin
      Rewrite(F1);
    end
    else
    begin
      Append(F1);
    end;
    jo := SO(sResult);
//    ShowMessage(jo.AsJSon(True,False));
    s := jo.S['MsgText'];
    MsgId := jo.I['MsgId'];
    sBreakApart(s,#13#10,sList);
    for i := 0 to sList.Count-1 do
    begin
      sValue := sList[i];
      writeln(F1, sValue);
    end;
    for I := sList.Count to 16-1 do
          writeln(F1, '');
 finally
    CloseFile(F1);
    sList.Free;
  end;
end;

procedure TFrmMain.Button8Click(Sender: TObject);
var
  iRet:Integer;
  Filename:string;
begin
  Filename := ExtractFilePath(Application.ExeName)+'Msg.txt';
  if ConnectScale then
  begin
    iRet := rtscaleUploadMessage(Connid, UploadMsgback);
    rtscaleDisConnect(Connid);
    if iRet=-1 then
      ShowMessage('Fail')
    else
      ShellExecute(0, 'open', PChar(FileName), nil, nil, SW_SHOWNORMAL);
  end;

end;

procedure TFrmMain.btnDownloadMsgClick(Sender: TObject);
var
  iRtn: integer;
  s,s1: AnsiString;
  i:Integer;
  iLongMsg:Integer;
  isOk:Boolean;
  c:AnsiChar;
  stmp:string;
begin
  iLongMsg := 0;
  isOk := True;
  if ConnectScale then
  begin
    rtscaleClearMessage(connid);//清除Message
    for i :=0  to 3 do
    begin
      ShowStatus(IntToStr(i+1));
    //  c := AnsiChar(i+48);
    //  s1 := StringOfChar(c,3);//    '第1行'+#13#10+'第2行';//最后一行不加回车
     // s := Format('this is a Message  1 of %0:d '+#13#10+'this is a Message 2 of %0:d ',[i]);
      stmp :=Format('%.5d@',[i+1]);  //00001  短消息240
      //s := 'testMessage'+IntToStr(i+1);
      s := '123'+#13#10
          +'456'+#13#10
          +'789';
//      s :=  stmp+'a234567890123456789012345678901234567890'+#13#10
//           +stmp+'a234567890123456789012345678901234567890'+#13#10
//           +stmp+'a234567890123456789012345678901234567890'+#13#10
//           +stmp+'a234567890123456789012345678901234567890'+#13#10
//           +stmp+'a23'+#13#10
//           +'01234567890'+#13#10
//           +'01234567890'+#13#10
//           +'01234567890';
//
//        s :=  stmp+'a23456789012345678901234567890'+#13#10
//           +stmp+'a23456789012345678901234567890'+#13#10
//           +stmp+'a23456789012345678901234567890'+#13#10
//           +stmp+'a23456789012345678901234567890'+#13#10
//           +stmp+'a23'+#13#10
//           +'0123'+#13#10
//           +'0123'+#13#10
//           +'0123'+#13#10
//           +'0123'+#13#10
//           +'012345'+#13#10
//           +'012345'+#13#10
//           +'012345'+#13#10
//           +'012345'+#13#10
//           +'012345'+#13#10
//           +'012345'+#13#10
//           +'012';
      if rtscaleDownLoadMessage(Connid,i,PAnsiChar(s), Length(s),iLongMsg)=-1 then
      begin
        isOk := False;
        ShowMessage('download Message Fail');
        Break;
      end;
    end;
    rtscaleDisConnect(Connid);
    if isOk then
    begin
      ShowMessage('download Message Ok');
    end;
  end;
end;

function TFrmMain.DownLoadNutritionTable: Boolean; //下载营养表
var
  i: Integer;
  s: Ansistring;
  jo,aSuperArray: ISuperObject;
begin
  Result := False;
  aSuperArray := SA([]);
  for i := 0 to 12 - 1 do  //最多12个
  begin
    jo := SO();
    s := edtNutriName.Text + InttoStr(i + 1);
    jo.S['Name'] := s; //最多 14个字符
    jo.I['iUnit'] := i mod 4 + 1; //单位最大为4  :1:kj,2:g,3:mg,4:ug
    aSuperArray.AsArray.Add(jo);
  end;
  s := aSuperArray.AsJSon(True,False);
//  ShowMessage(s);
   aSuperArray := nil;
  if rtscaleDownLoadNutritionTable(Connid,PAnsiChar(s)) < 0 then
  begin
    ShowMessage('down NutritionTableCluster Fail');
    Exit;
  end;
  Result := True;

end;

procedure TFrmMain.btnDownloadNutritionClick(Sender: TObject);
var
  iRet:Integer;
  b:Boolean;
begin
  if not ConnectScale then
  begin
    ShowMessage('connect Fail');
    exit;
  end;

  if DownLoadNutritionTable() then  //下载营养表
    lblDispPrgress.Caption := 'down NutritionTableCluster ok'
  else
  begin
    lblDispPrgress.Caption := 'down NutritionTableCluster Fail';
    rtscaleDisConnect(Connid);
    Exit;
  end;

  if rtscaleClearPluNutritionData(Connid) < 0 then
  begin
    lblDispPrgress.Caption := 'Clear Nutrition Data Fail';
    rtscaleDisConnect(Connid);
    Exit;
  end;
  b := DownLoadPluNutrition();
  rtscaleDisConnect(Connid);
  if b then  //下载plu的营养信息
     ShowMessage('down Nutrition ok')
  else
     ShowMessage('down Nutrition Fail');

end;

procedure TFrmMain.btnDownloadOtherFntClick(Sender: TObject);
var
  b:Boolean;
begin
  if ConnectScale then
  begin
    b := rtscaleDownLoadRarewords(Connid,DownloadFntFileCallback)=0;
    rtscaleDisConnect(Connid);
    if b then
      ShowMessage('download ok')
    else
      ShowMessage('download fail Fail');

  end;

end;

procedure UploadPluCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  I:Integer;
  F1: TextFile;
  FileName:string;
  jo: ISuperObject;
  s:Ansistring;
  PLUData:UGlobalfun.TPluData;
  ws:string;
begin
  FileName := ExtractFilePath(Application.ExeName)+'rplu.txt';
  FrmMain.ShowStatus( Format('%d',[iRecNO]));
  AssignFile(F1, FileName);
  try
    if (iRecNO=1) or (not FileExists(FileName)) then   //
      Rewrite(F1)
    else
      Append(F1);
   jo := SO(sResult);
   if (iRecNO>=80) and (iRecNO<=85) then
   begin
   //  showMessage(Format('recno=%d,so=%s',[iRecNO,strPas(sResult)]))
   end;

   FillChar(PLUData,SizeOf(PLUData),#0);
   PLUData.HotKey := jo.I['HotKey'];
   s := jo.S['PluName'];
   StrLCopy(PLUData.Name,PAnsiChar(s),Length(s));
   PLUData.LFCode := jo.I['LFCode'];
   s := Trim(jo.S['Code']);
   StrCopy(PLUData.Code,PAnsiChar(s));

   PLUData.BarCode := jo.I['BarCode'];
   PLUData.WeightUnit := jo.I['WeightUnit'];  	//称重单位 0-12
   PLUData.Deptment := jo.I['Deptment'];
   PLUData.Tare := jo.D['Tare'];  //皮重,逻辑换算后应在15Kg内
   PLUData.ShlefTime := jo.I['ShlefTime']; 	//保存期,0-365
   PLUData.PackageType := jo.I['PackageType']; 		//包装类型0:正常 1:定重 2：定价 3:定重定价 4:二维码
   PLUData.PackageWeight := jo.D['PackageWeight']; 	//包装重量/限重重量,逻辑换算后应在15Kg内
   PLUData.WeightUnit := jo.I['WeightUnit'];
   PLUData.Tolerance := jo.I['Tolerance'];  	//包装误差,0-20
   PLUData.Message1 := jo.I['Message1'];   	//信息1,0-10000
   PLUData.Message2 := jo.I['Message2'];
   PLUData.Message3 := jo.I['Message3'];
   PLUData.LabelId := jo.I['LabelId']; //标签id,0-255,8个Bit位分别对应A0-E1
   PLUData.Rebate := jo.I['Rebate']; //折扣,0-99
   PLUData.IsLock := jo.B['IsLock']; //锁定价格 true 锁定 , false不锁
   PLUData.QtyUnit := jo.I['QtyUnit'];   //数量单位
   PLUData.Ice := jo.D['Ice']; //含冰量
   PLUData.UnitPrice := jo.I['UnitPrice'];//单价
   PLUData.VAT := jo.D['VAT']; //阿拉伯定制版本用
   PLUData.DisCountPrice := jo.I['DisCountPrice'];//折扣价 AsiaRetail custom
   s := Trim(jo.S['Manufacturedate']);
   StrCopy(PLUData.Manufacturedate,PAnsiChar(s));
   PLUData.Pricemode := jo.I['Pricemode'];
   PLUData.Salemode := jo.I['Salemode'];
   PLUData.isPrnPackDate := jo.I['isPrnPackDate'];
   PLUData.isPrnExpiry := jo.I['isPrnExpiry'];
   PLUData.isPrnTime := jo.I['isPrnTime'];
   PLUData.AftertaxUP := jo.I['AftertaxUP'];
   s := jo.S['PluName2'];
   StrLCopy(PLUData.PluName2,PAnsiChar(s),Length(s));
   s := InttoStr(iRecNO)+#9+ PLUDataToStr(PLUData);
   writeln(F1,s);
  // sleep(2);
//   Flush(F1);
  finally
    CloseFile(F1);
  end;


end;

procedure TFrmMain.btnUploadPLUClick(Sender: TObject);
var
  FileName:string;
  iRet:Integer;
begin
  FileName := ExtractFilePath(Application.ExeName)+'rplu.txt';
  if not ConnectScale then
  begin
    ShowMessage('connect Fail');
    exit;
  end;
  iRet := rtscaleUploadPluData(Connid,UploadPluCallback);
  rtscaleDisConnect(Connid);
  if iRet>0 then
  begin
    ShellExecute(0, 'open', PChar(FileName), nil, nil, SW_SHOWNORMAL);
  end else if iRet=0 then
    ShowMessage('no data')
  else
    ShowMessage('upload error');

end;

function TFrmMain.ConnectScale: Boolean;
var
  sIp:AnsiString;
begin
  sIp := edtIP.Text;
  Result := rtscaleConnect(PAnsiChar(sIp),StrToInt(edtPort.Text),Connid)=0;
end;



procedure DownloadFntFileCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  s:string;
begin
  s := StrPas(sResult);
  FrmMain.ShowStatus(Format('download font[%s](%d/%d)',[s,iRecNo,ACount]));
  Application.ProcessMessages;
end;

procedure TFrmMain.downloadCustomFontClick(Sender: TObject);
var
  b:Boolean;
begin
  if ConnectScale then
  begin
    b :=rtscaleDownloadCustomFontFile(Connid,DownloadFntFileCallback);
    rtscaleDisConnect(Connid);
    if b then
      ShowMessage('download ok')
    else
      ShowMessage('download fail Fail');

  end;


end;

procedure TFrmMain.btnDownLoadPluClick(Sender: TObject);
var
  b:Boolean;
begin
  try
    if not ConnectScale then
    begin
      ShowMessage('connect Fail');
      exit;
    end;

    b := DownLoadPlu();
    if not b then
    begin
      rtscaleDisConnect(Connid);
      ShowMessage('Download plu Fail');
      Exit;
    end;
    if DownLoadHotKey()<>0 then
    begin
      rtscaleDisConnect(Connid);
      ShowMessage('Download plu Fail');
      Exit;
    end;
    b := true;
  finally
    if b then
    begin
      rtscaleDisConnect(Connid);
      ShowMessage('Down plu OK');
    end;

  end;


end;

procedure TFrmMain.btnGenOtherFntClick(Sender: TObject);
var
  sJson:AnsiString;
  jo:ISuperObject;
  i:Integer;
  binPath,sFilePath:string;
  iCharset:Integer;
begin
// if FontDialog1.Execute then
  begin
    jo := SO();
    binPath := ExtractFilePath(Application.ExeName);
    for i := CFONT_OTHER to CFONT_OTHER do
    begin
      sFilePath := binPath+CFontsFileName[CFONT_OTHER];
      if FileExists(sFilePath) then
       DeleteFile(sFilePath);
    end;

    if rtscaleCreateRarewords(CreateFntFileCallback)=0 then
       ShowMessage('ok')
    else
      ShowMessage('Fail');

  end;

end;

function TFrmMain.DownLoadPlu:Boolean;
var
  jo,aSuperArray: ISuperObject;
  s:Ansistring;
  i,J:Integer;
begin
  for J := 0 to 0 do // 5000
  begin
    aSuperArray := SA([]);
    for i:=0 to 3 do  //一次只能传4条 Can only pass 4 at a time
    begin
      jo := SO();
//      s := edtNutriName.Text;
      //s := 'pluName' +IntToStr(J * 4 + I + 1+10000)+StringofChar(AnsiChar(65+i),19)+'1end@'+StringofChar(AnsiChar(65+i),12)+'2end'; //52 charctes ukr
     //  s := '大白菜测试abc'+IntToStr(J * 4 + I + 1+10000);
      s := 'PluName_'+intToStr(J * 4 + I + 1);//IntToStr(J * 4 + I + 1+10000);+'1end^'+StringofChar(AnsiChar(65+i),30)+'2end';
    //  s :='سيببسي123'+ 'plueitem' + (J * 4 + i + 1).ToString();
    //  s := 'pluName' +IntToStr(J * 4 + I + 1+10000)+StringofChar(AnsiChar(65+i),36-12-3)+'end_'+StringofChar(AnsiChar(65+i),10)+'2end';
//      s :='الأندلس للبرمجيات' + 'plueitem' + (J * 4 + i + 1).ToString();

      jo.S['PluName'] := s; //品名,36个字符  Name, 36 characters
      jo.S['PluName2'] := '_22222'; //品名2，定制版本，目前只有卡塔尔使用
      jo.I['LFCode'] := J * 4 + I+1;   // J * 4 + I + 1;// + 10000; //生鲜码,1-999999,唯一识别每一种生鲜商品 fresh code, 1-999999, uniquely identifies each fresh product
      jo.S['Code'] := '1234567890123'; //;IntToStr(J * 4 + I + 1 + 10000); //货号，10位数字,用来组成条码  goods no, 10 digits
      jo.I['BarCode'] := 99; //条码类型,0-99   barcode type, 0-99 101~110
      jo.I['UnitPrice'] := 100;// 12345678;  //;//单价为整数,无小数模式,0-9999999    unit price, no decimal mode, 0-9999999
     {称重单位  0:50g,1:g,2:10g,   3:100g,4:Kg,5:Oz,  6:LB,7:500g,8:600g 9:,PCS(g),10:PCS(kg),  11:PCS(oz),12: CS(Lb)
       0~8：称重单 位
       9~12：计件单位
     }
      jo.I['WeightUnit'] := 4;//称重单位 Weighing Units  0-12
      jo.I['QtyUnit'] := 0;  //数量单位 0~15
      jo.I['Deptment'] := 2; //部门,2位数字,用来组成条码  Department, two digits
      jo.D['Tare'] :=0;  //去皮质量,逻辑换算后应在15Kg内   Tare, logical conversion should be within 15Kg
      jo.I['ShlefTime'] :=15;  //保存期,0-365  Shelf life, 0-365
      jo.I['PackageType'] :=0;//包装类型   Pack Type  0:正常 1:定重 2：定价 3:定重定价 4:二维码   Package Type 0: Normal 1: Fixed Weight 2: Pricing 3: Fixed Price 4: QR Code
      jo.D['PackageWeight'] := 0;// //包装重量/限重重量,逻辑换算后应在15Kg内  Package weight, logical conversion should be within 15Kg
      jo.I['Tolerance'] :=0; //包装误差,0-20   Packaging error, 0-20
      jo.I['Message1'] := 1211;//J*4+I+1; //信息1,0-10000 Message 1,0- 10000
      jo.I['Message2'] := 1212; 		//信息2, 0-255
      jo.I['LabelId'] := 0;;	//标签类型1,2,4,8,16,32,64,128,,3,12 分别对应标签编缉器RTLabel.exe的标签类型(A0,A1,B0,B1,C0,C1,D0,D1,E0,E1)
      jo.I['Rebate'] := 0;  	//折扣,0-99   discounts, 0-99
      jo.I['Ice'] := 0;
      jo.D['VAT'] := 12;
      jo.I['Message3'] := 2;
      jo.B['isChgPrice'] := true; //不允许变价
      jo.S['Manufacturedate'] := '2023-06-10';  //生产日期
      jo.I['Pricemode'] := 3;
      jo.I['Salemode'] := 0;
      jo.I['isPrnPackDate'] := 0;
      jo.I['isPrnExpiry'] := 0;
      jo.I['isPrnTime'] := 0;
      jo.I['isPrnExpiryTime'] := 0;
      jo.I['isTraceable']:= 1; //0: 不允许追溯 1：允许追溯
      jo.D['AftertaxUP'] := 112;

//      jo.I['DisCountPrice'] := 0; 折后价，定制版本  马来西亚定制版本
//      jo.I['AddInfoId'] := J * 4 + I + 1;
//      jo.I['AddInfoId2'] := J * 4 + I + 1;
//      jo.I['AddInfoId3'] := J * 4 + I + 1;
      aSuperArray.AsArray.Add(jo);
    end;
     //Transfer one PLU
    lblDispPrgress.Caption := IntToStr((J+1) * 4);
    lblDispPrgress.Refresh;

    s := aSuperArray.AsJSon(True,False);
  //  ShowMessage(s);
    aSuperArray := nil;
    Result := rtscaleDownLoadPLU(Connid,PAnsiChar(s),J)=0;
    if (not Result) then
      exit;
    Application.ProcessMessages;
  end;
end;

function TFrmMain.DownLoadPluNutrition: Boolean;
var
  I, J, K: Integer;
  s: Ansistring;
  jo,aSuperArray: ISuperObject;
begin
  Result := False;
  for J := 0 to 10 do
  begin
    aSuperArray := SA([]);
    for I := 0 to 3 do
    begin
      jo := SO();
      s := 'pluname' +IntToStr(J * 4 + I + 1); //IntToStr(J * 4 + I + 1+1000);
      jo.S['GroupTitle'] := s; //Lenght <12
      jo.I['LFCode'] := J * 4 + I + 1 + 10000; //生鲜码
      jo['isPrint'] := SA([]);
      jo['percent'] := SA([]);
      jo['value'] := SA([]);

      for K := 0 to 11 do
      begin
        jo.A['isPrint'].Add(so(true));
        jo.A['percent'].Add(so(50+k));
        jo.A['value'].Add(so((30+k)*1)); ////含量,注意：下发时，要转成整数，根据单位:1:kj*1,2:g*10,3:mg*10,4:ug*100 乘于对于的基数
      end;
      aSuperArray.AsArray.Add(jo);
    end;

    lblDispPrgress.Caption := IntToStr((J+1) * 4);
    lblDispPrgress.Refresh;
    s := aSuperArray.AsJSon(True,False);
//    ShowMessage(s);
    if rtscaleDownLoadPluNutrition(Connid, PAnsiChar(s)) < 0 then
    begin
      Result := False;
      ShowMessage(Format('down plu Nutrition TableCluster Fail[%d]',[J]));
      Exit;
    end;
    Result := True;
     aSuperArray := nil;
  end;


end;

procedure TFrmMain.edtPortKeyPress(Sender: TObject; var Key: Char);
begin
  if not (Key in['0'..'9',#8]) then
    Key := #0;
end;

procedure TFrmMain.FormCreate(Sender: TObject);
begin
//  if not SysConfig.isUseAI then
//  begin
//    btnUploadAIMsg.Visible := false;
//    btnClearAllAddinfo.Visible := false;
//    btnDelSomeAddinfo.Visible := false;
//    SysConfig.IsOnlyUseRT1 := true;
//  end else
//  begin
//    btnUploadAIMsg.Visible := true;
//    btnClearAllAddinfo.Visible := true;
//    btnDelSomeAddinfo.Visible := true;
//    SysConfig.IsOnlyUseRT1 := false;
//  end;


end;

procedure TFrmMain.edtIPKeyPress(Sender: TObject; var Key: Char);
begin
  if not (Key in['C','O','M','0'..'9','.',#8]) then
    Key := #0;
end;

procedure TFrmMain.ShowStatus(s: String);
begin
   lblDispPrgress.Caption := s;
   lblDispPrgress.Refresh;
end;




function TFrmMain.DownLoadHotKey: Integer;
const
//   HOTKEY_LEN = 50;
//   HotKey_Page = 5;
   HOTKEY_LEN = 84;
   HotKey_Page = 3;
var
  i,j:Integer;
  HotKeyTable: THotKeyTable;
  HotkeyBuf:array[0..260] of byte; //热键列表，224btye有效
begin
  FillChar(HotKeyTable, sizeof(THotKeyTable), 0);
  FillChar(HotkeyBuf, sizeof(HotkeyBuf), 0);
  for i := 0 to 224-1 do
    HotkeyBuf[i] := i+1;//热键列表，存放的是生鲜码
  for i := 0 to HotKey_Page-1 do
  begin
    FillChar(HotKeyTable, sizeof(THotKeyTable), 0);
    for j := 0 to HOTKEY_LEN-1 do
       HotKeyTable[j] := HotkeyBuf[i*HOTKEY_LEN+j];
    Result := rtscaleDownLoadHotkey(Connid, @HotKeyTable, 2);
  end;

end;


procedure TFrmMain.btnDownDeptClick(Sender: TObject);
var
  I: Integer;
  s: Ansistring;
  jo,aSuperArray: ISuperObject;
  iRet:Integer;
begin
  if not ConnectScale then
  begin
    ShowMessage('connect Fail');
    exit;
  end;
  aSuperArray := SA([]);
  for I := 1 to 30 do    //最多下载59条
  begin
    jo := SO();
    jo.B['IsPrintDeptId'] := True;
    jo.B['IsPrintDeptName'] := False;
    jo.I['DeptId'] := I;
    jo.S['DeptName'] := 'Department'+IntToStr(I);
    jo.D['SGST'] := I;//*1.2;
    jo.D['CGST'] := I;//+0.5;
    aSuperArray.AsArray.Add(jo);
  end;
  s := aSuperArray.AsJSon(True,False);
  iRet := rtscaleDownLoadDepartment(Connid, PAnsiChar(s),true);
  rtscaleDisConnect(Connid);
  if iRet = 0 then
    ShowMessage('ok')
  else
    ShowMessage('Fail');
    aSuperArray := nil;

end;



procedure CreateFntFileCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  s:string;
begin
  s := StrPas(sResult);
  FrmMain.ShowStatus(Format('generate font[%s](%d/%d)',[s,iRecNo,ACount]));
  Application.ProcessMessages;
end;



procedure TFrmMain.Button28Click(Sender: TObject);
var
  iRet:Integer;
  n:cardinal;
begin
  if ConnectScale then
  begin
    iRet := rtscaleDownLoadDeletePLU(Connid,StrToIntDef(edtPlu.Text,0));
    rtscaleDisConnect(Connid);
    if iRet=0 then
      ShowMessage('delete plu ok')
    else
      ShowMessage('delete plu  Fail');
  end;
end;

procedure TFrmMain.Button2Click(Sender: TObject);
const
  CFONT_8X16=0;
  CFONT_8X24=1;// 8x24.fnt
  CFONT_16X32=2;
  CFONT_12X24=3;
  CFONT_8H16=4;
  CFONT_16H16=5;
  CFONT_OTHER=6;
  CFONT_24L24=7;
  CFONT_12L24=8;
  CFONT_HZWORD=9;  //简体12x24,繁体24x24


  //双字节字体：16H16.FNT（显示字体），24L24.FNT,12L24.FNT，HZ12x24.FNT（打印字体）
  CFontsFileName: array[0..9, 0..15] of AnsiChar = ('8x16.fnt', '8x24.fnt', '16x32.fnt', '12x24.fnt', '8H16.fnt', '16H16.fnt',
            'Other.FNT', '24L24.FNT', '12L24.FNT','HZWORD.FNT'); //HZ12x24.FNT 简体汉字 FT24X24繁体汉字


var
  sJson:AnsiString;
  jo:ISuperObject;
  i:Integer;
  binPath,sFilePath:string;
  iCharset:Integer;
begin
 // iCharset := DEFAULT_CHARSET;//  StrToInt(edtFontCharset.Text);
 //要生成CFONT_HZWORD 字体，一定要调用 rtscaleLoadHZCode;
  rtscaleLoadHZCode(False); //true 调用'HzwordFull.DAT'  false:'Hzword.DAT';
  if FontDialog1.Execute then
  begin
    jo := SO();
    jo.S['DoubleFontName'] := FontDialog1.Font.Name; //双字节字体名
    jo.S['SingleFontName'] := FontDialog1.Font.Name; //单字节字体名
    jo.I['DoubleWeight'] := cboxFontWeight.ItemIndex; //双字节字体粗细
    jo.I['SingleWeight'] := cboxFontWeight.ItemIndex; //单字节字体粗细
    jo.I['SingleFntCharSet']  := FontDialog1.Font.Charset; //单字节符集  DEFAULT_CHARSET
    jo.I['DoubleFntCharSet']  := FontDialog1.Font.Charset; //双字节字符集  //CHINESEBIG5_CHARSET
    jo.B['isDownDoubleFont']  := True;//是否下载双字节字体
    jo.I['FntStart']  := CFONT_8X16;//要下载字体的开始
    jo.I['FntEnd']  := CFONT_HZWORD;// 要下载字体的结束
    binPath := ExtractFilePath(Application.ExeName);
    //for i := CFONT_8X16 to CFONT_HZWORD do

    for i := CFONT_OTHER to CFONT_OTHER do
    begin
      sFilePath := binPath+CFontsFileName[i];
      if FileExists(sFilePath) then
       DeleteFile(sFilePath);
    end;


    sJson  := jo.AsJSon(True,False);

   //ShowMessage(sJson);
    if rtscaleCreateFontLib(PAnsiChar(sJson),  CreateFntFileCallback)=0 then
       ShowMessage('ok')
    else
      ShowMessage('Fail');

  end;
end;
procedure TFrmMain.Button3Click(Sender: TObject);
var
  I: Integer;
  s: Ansistring;
  jo,aSuperArray: ISuperObject;
  iRet:Integer;
begin
  if not ConnectScale then
  begin
    ShowMessage('connect Fail');
    exit;
  end;
  aSuperArray := SA([]);
  for I := 1 to 8 do    //最多下载8条
  begin
    jo := SO();
    jo.S['Vender'] := 'Vender'+IntToStr(I);
    jo.S['Password'] := '123456';//最多6位
    aSuperArray.AsArray.Add(jo);
  end;
  s := aSuperArray.AsJSon(True,False);
    iRet := rtscaleDownLoadVenderPassWord(Connid, PAnsiChar(s));
  rtscaleDisConnect(Connid);
  if iRet = 0 then
    ShowMessage('ok')
  else
    ShowMessage('Fail');
    aSuperArray := nil;
end;


procedure TFrmMain.Button4Click(Sender: TObject);
var
  sRet:AnsiString;
  iret:integer;
  jo:ISuperObject;
begin
  if ConnectScale then
  begin
    SetLength(sRet,256);
    iret := rtscaleUploadFirmwareVersion(Connid,PAnsiChar(sRet));
    jo := SO(sRet);
    rtscaleDisConnect(Connid);
    if iret=0 then
       showMessage( jo.S['Version'])
    else
      ShowMessage('Fail');

  end
end;

procedure TFrmMain.Button6Click(Sender: TObject);
var
  iRet,iver:Integer;
begin
  if ConnectScale then
  begin
    iRet := rtscaleCheckFirmwareVer(Connid,iver);
    rtscaleDisConnect(Connid);
    if iRet=0 then
      ShowMessage('version:'+IntTostr(iver))
    else
      ShowMessage('Check Scale Version Fail');

  end;

end;

procedure TFrmMain.btnSetTransBreakClick(Sender: TObject);
begin
  rtscaleSetTransBreak(0);
end;

procedure TFrmMain.btnCreateBoldFntClick(Sender: TObject);
begin
  if FontDialog1.Execute() then
     rtscaleCreateCustomFont(FontDialog1.Font.Name,CreateFntFileCallback);
end;



procedure UploadCustomHotkeyCallback(sResult: PAnsiChar; iRecNO: Integer; ACount: Integer); stdcall;
var
  i,j,iLen: Integer;
  sRetJson: PAnsiChar;
  jo: ISuperObject;
  ObjAry:TSuperArray;
  s:string;
begin
  jo :=SO(sResult);
  ObjAry := jo.AsArray;
  s := '';
  for i := 0 to ObjAry.Length-1  do
  begin
    s := s + Format('HotKey=%d,KeyValue=%d',[ObjAry[i].I['HotKey'],ObjAry[i].I['KeyValue']])+#13#10;
  end;
  ShowMessage(s);
end;



procedure TFrmMain.btnUploadCustomHotkeyClick(Sender: TObject);
var
  iret:Integer;
begin
  if  ConnectScale then
  begin
    iret := rtscaleUploadCustomHotkey(Connid,UploadCustomHotkeyCallback);
    rtscaleDisConnect(Connid);
    if iret=0 then
     // showMessage('ok')
    else
      showMessage('Fail');
  end else
     ShowMessage('connect Fail');

end;



end.

