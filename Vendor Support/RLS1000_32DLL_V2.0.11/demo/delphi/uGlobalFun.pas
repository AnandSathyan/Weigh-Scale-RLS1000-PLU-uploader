unit uGlobalFun;

interface
uses Windows,System.Classes,System.SysUtils;

 type
   TaAlignMode=(taLeft,taRight);

   TData=Array[0..312] of Byte;
   TItem=Array[0..4] of Byte;

  //上传的PLU数据
  TPluData = packed record			//PLU信息结构
    HotKey:Longint;
    Name: array[0..72] of AnsiChar; //品名; 	//品名,36个字符
    LFCode: Longint;	//生鲜码,1-999999,唯一识别每一种生鲜商品
    Code: array[0..13] of AnsiChar;	//货号，10位数字,用来组成条码
    BarCode: Longint;	//条码类型,0-99
    UnitPrice: Longint;	//单价,无小数模式,0-9999999
    WeightUnit: Longint;	//称重单位 0-12
    Deptment: Longint;	//部门,2位数字,用来组成条码
    Tare: Double;	//皮重,逻辑换算后应在15Kg内
    ShlefTime: Longint;	//保存期,0-365
    PackageType: Longint;	//包装类型0:正常 1:定重 2：定价 3:定重定价 4:二维码
    PackageWeight: Double;	//包装重量/限重重量,逻辑换算后应在15Kg内
    Tolerance: Longint;	//包装误差,0-20
    Message1: Longint;	//信息1,0-10000
    Message2: integer;	//信息2,0-197
    Message3: integer;
    LabelId: Byte;	//多标签,0-255,8个Bit位分别对应A0-D1
    Rebate: ShortInt;	//折扣,0-99
    Recomdays: Integer; //推荐天数
    IsLock: Boolean;  //锁定价格 true 锁定 , false不锁
    QtyUnit: Integer; //数量单位
    Ice:Double; //含冰量
    VAT:Double;
    DisCountPrice:Longint;//折扣价 马来西亚定制版本
    PluName2: array[0..36] of AnsiChar; //第二品名 ,36个字符
    Manufacturedate: array[0..10] of AnsiChar;//生产日期
    Pricemode:Integer;//价格模式 印度Posiflex
    Salemode:Integer; //销售模式 印度Posiflex
    isPrnPackDate:byte; //是否打印包装日期 0:打印（默认）,1:不打印
    isPrnExpiry: byte;//是否打印有效期 0:打印（默认）,1:不打印
    isPrnTime:byte; //是否打印包装和有效期的时间  0:打印（默认）,1:不打印
    isTraceable:byte; //是否允许追溯
    AftertaxUP:double;
  end;
   TScaleAccount = packed record
    UserID: Longint;  //
    PluName: array[0..36] of AnsiChar; //品名
    LFCode: Longint; //生鲜码
    UnitPrice: Double; //单价
    WeightUnit: Longint; //单位
    TotalPrice: Double; //总价
    Weight: Double; //重量
    SaleTime: TDateTime; //销售时间
    Rebate: Longint; //折扣
    OnlineTime: TDateTime; //上次清除流水的时间
    Quantity: Longint;
    Clerk: Longint;
    SerialNum:Longint; //WH流水号 或委内瑞拉的小票号
//    MarkD: string;
  end;

  function BINToBCD(lBin:Longint;Count:Integer):TItem; //转BCD码
  function GetSendTestData(iProtocol:Integer):TData; //测试发送指令
  function getUploadTestData(iProtocol:Integer):TData;  //测试上传数据
  Function AnsiMemCopy(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
  function sBreakApart(BaseString, BreakString: Ansistring; StringList: TStringList): TStringList;
  function AligSpaceStr(s:AnsiString; iLen:Integer; AlignMode:TaAlignMode=taLeft):AnsiString; //左/右对齐
  function YMDHMSToDateTime(sData:Ansistring):TDateTime;
  Function PLUDataToStr(PLU:TPluData):AnsiString;
  function getScaleProtocol():TData;//秤协议
  function RTrim(s: Ansistring; ch: AnsiChar): Ansistring;
  function AnsiToUnicode(s:Ansistring):WideString;
  function UnicodeToAnsi(s:WideString):Ansistring;
 const
   WEIGHTUNITCOUNT=12;
   SendDataLen=261;
   C_WeightUnit: array[0..WEIGHTUNITCOUNT] of string[10] = ('50g', 'g', '10g', '100g', 'Kg', 'oz', 'Lb', '500g', '600g', 'PCS(g)', 'PCS(Kg)', 'PCS(oz)', 'PCS(Lb)');

  //升级状态
  Upgrade_Status_StartCommandFail = 0; //发送升级命令失败
  Upgrade_Status_upgrading = 1; //正在更新
  Upgrade_Status_upgradeFail = 2;//更新失败
  Upgrade_Status_EndCommandFail = 3;//发送升级结束命令失败
  Upgrade_Status_upgradeOk  = 4; // 升级成功

 var
   FormatStr: array[0..WEIGHTUNITCOUNT] of string[10] = ('%6.0f', '%6.0f', '%6.0f', '%6.0f', '%6.3f', '%6.1f', '%6.3f', '%6.0f', '%6.0f', '%6.0f', '%6.3f', '%6.1f', '%6.3f');

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
            'OTHERHZ.FNT', '24L24.FNT', '12L24.FNT','HZWORD.FNT'); //HZ12x24.FNT 简体汉字 FT24X24繁体汉字


implementation

function BINToBCD(lBin:Longint;Count:Integer):TItem;
var
  Bcd:TItem;
  I,J:Integer;
  Val:LongInt;
begin
  J:=(Count-1) div 2;
  for I:=J Downto 0 do
  begin
    Val:=lBin div 10;
    Bcd[I]:=((val mod 10) shl 4)+(lBin mod 10);
    lBin:=lBin div 100;
  end;
  Result :=Bcd;
end;

function GetSendTestData(iProtocol:Integer):TData; //测试发送指令，--断开秤
var
  Data:TData;
  Sum:LongInt;
  I:Integer;
  DataItem:TItem;
begin
  FillChar(Data,SizeOf(TData),0);
  Data[0] := $0e;
  Data[1] := $02;
  Data[2] := $00;
  DataItem:=BinToBcd(1234,8);
  Data[3]:=DataItem[3];
  Data[4]:=DataItem[2];
  Data[5]:=DataItem[1];
  Data[6]:=DataItem[0];
  Sum:=0;
  if iProtocol=1 then
  begin
    for I:=0 to 262 do
    begin
      Sum:=Sum+Data[I];
    end;
    Data[263]:=LoByte(LoWord(Sum));
    Data[264]:=HiByte(LoWord(Sum));
  end else
  begin
    for I:=0 to 258 do
    begin
      Sum:=Sum+Data[I];
    end;
    Data[259]:=LoByte(LoWord(Sum));
    Data[260]:=HiByte(LoWord(Sum));
  end;

  Result := Data;
end;




function getUploadTestData(iProtocol:Integer):TData;
var
  Data:TData;
  Sum:LongInt;
  I:Integer;
begin
  FillChar(Data,SizeOf(TData),0);
  if iProtocol=1 then
  begin
    Data[0] := $D2;
    Data[1] := $2D;
    Data[2] := $00;
    Data[3] := $00;
    Data[4] := $00;
    Data[5] := $00;
    for I:=0 to 262 do
    begin
      Sum:=Sum+Data[I];
    end;
    Data[263]:=LoByte(LoWord(Sum));
    Data[264]:=HiByte(LoWord(Sum));
 end else
 begin
   Data[0] := $0E;
   Data[1] := $08;
   Data[2] := $00;
   Data[3] := $00;
   Data[4] := $00;
   Data[5] := $00;
   Sum:=0;
    for I:=0 to 258 do
    begin
      Sum:=Sum+Data[I];
    end;
    Data[259]:=LoByte(LoWord(Sum));
    Data[260]:=HiByte(LoWord(Sum));
 end;
    Result := Data;
end;

function getScaleProtocol():TData;
var
  Data:TData;
  Sum:LongInt;
  I:Integer;
begin
  FillChar(Data,SizeOf(TData),0);
  Data[0] := $08;
  Data[1] := $00;
  Data[2] := $00;
  Sum:=0;
  for I:=0 to 258 do
  begin
    Sum:=Sum+Data[I];
  end;
  Data[259]:=LoByte(LoWord(Sum));
  Data[260]:=HiByte(LoWord(Sum));
  Result := Data;
end;

Function AnsiMemCopy(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
Var
  I:Longint;
begin
  for I:=0 to MaxLen-1 do
    Dest[I]:=Source[I];
  Result:=Dest;
end;

function sBreakApart(BaseString, BreakString: AnsiString; StringList: TStringList): TStringList;
var
  ipos: Integer;
begin
  repeat
    ipos := Pos(BreakString, BaseString);
    if ipos = 0 then
      StringList.add(BaseString)
    else
    if(ipos>1) then
      StringList.add( Copy(BaseString, 1, ipos - 1))
    else StringList.add('');
    BaseString := Copy(BaseString, ipos + length(BreakString),
                      length(BaseString) - ipos);
  until ipos = 0;
  result := StringList;
end;

function AligSpaceStr(s:AnsiString; iLen:Integer; AlignMode:TaAlignMode):AnsiString; //左/右对齐
begin
  if AlignMode=taLeft then
    Result := s+StringofChar(' ',iLen-Length(s))
  else
    Result := StringofChar(' ',iLen-Length(s))+s;
end;

function YMDHMSToDateTime(sData:Ansistring):TDateTime;
var
  s:string;
begin
  if (sData='') then
    Result := 0
  else
  begin
    s := Format('%s-%s-%s %s:%s:%s',[Copy(sData,1,4),Copy(sData,5,2),Copy(sData,7,2),
                                   Copy(sData,9,2),Copy(sData,11,2),Copy(sData,13,2)
                                  ]);
    Result := StrToDateTime(s);
  end;

end;

Function PLUDataToStr(PLU:TPluData):AnsiString;
begin
  Result:='';
  Result := IntToStr(plu.HotKey)+#9+StrPas(PLU.Name)+#9+IntToStr(PLU.LFCode)+#9
             + StrPas(Plu.Code)+#9+IntToStr(PLU.BarCode)+#9+InttoStr(PLU.UnitPrice)+#9
             +Format('%x',[PLU.WeightUnit])+#9+InttoStr(PLU.Deptment)+#9
             +Format(FormatStr[Plu.WeightUnit],[PLU.Tare])+#9
             +IntToStr(PLU.ShlefTime)+#9+IntToStr(PLU.PackageType)+#9
             +Format(FormatStr[Plu.WeightUnit],[PLU.PackageWeight])+#9
             +IntToStr(PLU.Tolerance)+#9 +IntToStr(PLU.Message1)+#9+IntToStr(PLU.Message2)+#9
             +IntToStr(PLU.LabelId)+#9   +IntToStr(PLU.Rebate)+#9
             +IntToStr(PLU.QtyUnit) +#9
             +InttoStr(PLU.Recomdays) +#9
             +FormatFloat('0.0',PLU.Ice)+#9+InttoStr(PLU.DisCountPrice)+#9
             +InttoStr(PLU.Message3)+#9
             +StrPas(PLU.PluName2)+#9
             +StrPas(PLU.Manufacturedate)+#9
             +IntToStr(PLU.Pricemode)+#9
             +IntToStr(PLU.Salemode)+#9
             +IntToStr(PLU.isPrnPackDate)+#9
             +IntToStr(PLU.isPrnExpiry)+#9
             +IntToStr(PLU.isPrnTime)+#9
             +IntToStr(PLU.isTraceable)+#9
             +Format('%.2f',[PLU.AftertaxUP])
end;

function RTrim(s: Ansistring; ch: AnsiChar): Ansistring;
begin
  if(s='') then exit;
  while (length(s)>0) and (s[length(s)] = ch) do
     SetLength(s,length(s)-1);
  result := s;
end;


function AnsiToUnicode(s:Ansistring):WideString;
var
  lpWideChar:PWideChar;
  len:Integer;
begin
  len := ( Length(s) + 1 ) * 2;
  GetMem(lpWideChar, len);
  ZeroMemory(lpWideChar, len);
  MultiByteToWideChar(CP_ACP,MB_PRECOMPOSED, PAnsiChar(s), Length(s),lpWideChar, Len);
  Result := lpWideChar;
  FreeMem(lpWideChar);

end;


function UnicodeToAnsi(s:WideString):Ansistring;
var
  lpChar:PAnsiChar;
  len:integer;
begin
  len := Length(s) * 2;
  GetMem(lpChar,len);
  ZeroMemory(lpChar, len);
  WideCharToMultiByte(1256, WC_COMPOSITECHECK, PWideChar(s),Length(s),lpChar,Len, nil, nil );  //1256
  Result := lpChar;
  FreeMem(lpChar);
end ;



end.
