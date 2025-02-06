unit uGlobalFun;

interface
uses Windows,System.Classes,System.SysUtils;

 type
   TaAlignMode=(taLeft,taRight);

   TData=Array[0..312] of Byte;
   TItem=Array[0..4] of Byte;

  //�ϴ���PLU����
  TPluData = packed record			//PLU��Ϣ�ṹ
    HotKey:Longint;
    Name: array[0..72] of AnsiChar; //Ʒ��; 	//Ʒ��,36���ַ�
    LFCode: Longint;	//������,1-999999,Ψһʶ��ÿһ��������Ʒ
    Code: array[0..13] of AnsiChar;	//���ţ�10λ����,�����������
    BarCode: Longint;	//��������,0-99
    UnitPrice: Longint;	//����,��С��ģʽ,0-9999999
    WeightUnit: Longint;	//���ص�λ 0-12
    Deptment: Longint;	//����,2λ����,�����������
    Tare: Double;	//Ƥ��,�߼������Ӧ��15Kg��
    ShlefTime: Longint;	//������,0-365
    PackageType: Longint;	//��װ����0:���� 1:���� 2������ 3:���ض��� 4:��ά��
    PackageWeight: Double;	//��װ����/��������,�߼������Ӧ��15Kg��
    Tolerance: Longint;	//��װ���,0-20
    Message1: Longint;	//��Ϣ1,0-10000
    Message2: integer;	//��Ϣ2,0-197
    Message3: integer;
    LabelId: Byte;	//���ǩ,0-255,8��Bitλ�ֱ��ӦA0-D1
    Rebate: ShortInt;	//�ۿ�,0-99
    Recomdays: Integer; //�Ƽ�����
    IsLock: Boolean;  //�����۸� true ���� , false����
    QtyUnit: Integer; //������λ
    Ice:Double; //������
    VAT:Double;
    DisCountPrice:Longint;//�ۿۼ� �������Ƕ��ư汾
    PluName2: array[0..36] of AnsiChar; //�ڶ�Ʒ�� ,36���ַ�
    Manufacturedate: array[0..10] of AnsiChar;//��������
    Pricemode:Integer;//�۸�ģʽ ӡ��Posiflex
    Salemode:Integer; //����ģʽ ӡ��Posiflex
    isPrnPackDate:byte; //�Ƿ��ӡ��װ���� 0:��ӡ��Ĭ�ϣ�,1:����ӡ
    isPrnExpiry: byte;//�Ƿ��ӡ��Ч�� 0:��ӡ��Ĭ�ϣ�,1:����ӡ
    isPrnTime:byte; //�Ƿ��ӡ��װ����Ч�ڵ�ʱ��  0:��ӡ��Ĭ�ϣ�,1:����ӡ
    isTraceable:byte; //�Ƿ�����׷��
    AftertaxUP:double;
  end;
   TScaleAccount = packed record
    UserID: Longint;  //
    PluName: array[0..36] of AnsiChar; //Ʒ��
    LFCode: Longint; //������
    UnitPrice: Double; //����
    WeightUnit: Longint; //��λ
    TotalPrice: Double; //�ܼ�
    Weight: Double; //����
    SaleTime: TDateTime; //����ʱ��
    Rebate: Longint; //�ۿ�
    OnlineTime: TDateTime; //�ϴ������ˮ��ʱ��
    Quantity: Longint;
    Clerk: Longint;
    SerialNum:Longint; //WH��ˮ�� ��ί��������СƱ��
//    MarkD: string;
  end;

  function BINToBCD(lBin:Longint;Count:Integer):TItem; //תBCD��
  function GetSendTestData(iProtocol:Integer):TData; //���Է���ָ��
  function getUploadTestData(iProtocol:Integer):TData;  //�����ϴ�����
  Function AnsiMemCopy(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
  function sBreakApart(BaseString, BreakString: Ansistring; StringList: TStringList): TStringList;
  function AligSpaceStr(s:AnsiString; iLen:Integer; AlignMode:TaAlignMode=taLeft):AnsiString; //��/�Ҷ���
  function YMDHMSToDateTime(sData:Ansistring):TDateTime;
  Function PLUDataToStr(PLU:TPluData):AnsiString;
  function getScaleProtocol():TData;//��Э��
  function RTrim(s: Ansistring; ch: AnsiChar): Ansistring;
  function AnsiToUnicode(s:Ansistring):WideString;
  function UnicodeToAnsi(s:WideString):Ansistring;
 const
   WEIGHTUNITCOUNT=12;
   SendDataLen=261;
   C_WeightUnit: array[0..WEIGHTUNITCOUNT] of string[10] = ('50g', 'g', '10g', '100g', 'Kg', 'oz', 'Lb', '500g', '600g', 'PCS(g)', 'PCS(Kg)', 'PCS(oz)', 'PCS(Lb)');

  //����״̬
  Upgrade_Status_StartCommandFail = 0; //������������ʧ��
  Upgrade_Status_upgrading = 1; //���ڸ���
  Upgrade_Status_upgradeFail = 2;//����ʧ��
  Upgrade_Status_EndCommandFail = 3;//����������������ʧ��
  Upgrade_Status_upgradeOk  = 4; // �����ɹ�

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
  CFONT_HZWORD=9;  //����12x24,����24x24



  //˫�ֽ����壺16H16.FNT����ʾ���壩��24L24.FNT,12L24.FNT��HZ12x24.FNT����ӡ���壩
  CFontsFileName: array[0..9, 0..15] of AnsiChar = ('8x16.fnt', '8x24.fnt', '16x32.fnt', '12x24.fnt', '8H16.fnt', '16H16.fnt',
            'OTHERHZ.FNT', '24L24.FNT', '12L24.FNT','HZWORD.FNT'); //HZ12x24.FNT ���庺�� FT24X24���庺��


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

function GetSendTestData(iProtocol:Integer):TData; //���Է���ָ�--�Ͽ���
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

function AligSpaceStr(s:AnsiString; iLen:Integer; AlignMode:TaAlignMode):AnsiString; //��/�Ҷ���
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
