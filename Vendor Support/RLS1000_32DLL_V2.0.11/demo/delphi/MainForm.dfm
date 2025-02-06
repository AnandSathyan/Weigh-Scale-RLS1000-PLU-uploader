object FrmMain: TFrmMain
  Left = 500
  Top = 187
  Caption = 'FrmMain'
  ClientHeight = 753
  ClientWidth = 1058
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clWindowText
  Font.Height = -14
  Font.Name = #23435#20307
  Font.Style = []
  OldCreateOrder = False
  Position = poDesigned
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 14
  object lblAddr: TLabel
    Left = 45
    Top = 11
    Width = 16
    Height = 16
    Caption = 'ip'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = #23435#20307
    Font.Style = []
    ParentFont = False
  end
  object lblDispPrgress: TLabel
    Left = 213
    Top = 8
    Width = 297
    Height = 25
    AutoSize = False
    Caption = '0'
    WordWrap = True
  end
  object Label2: TLabel
    Left = 619
    Top = 8
    Width = 92
    Height = 16
    Caption = 'Nutrition Name'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -14
    Font.Name = 'Arial'
    Font.Style = []
    ParentFont = False
  end
  object Label1: TLabel
    Left = 13
    Top = 36
    Width = 64
    Height = 16
    Caption = 'BaudRate'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = #23435#20307
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 210
    Top = 39
    Width = 385
    Height = 14
    Caption = 'When the BaudRate  is zero, use ip, otherwise use RS232'
  end
  object Label4: TLabel
    Left = 43
    Top = 283
    Width = 77
    Height = 36
    Alignment = taCenter
    AutoSize = False
    Caption = 'font Weight'
    Layout = tlCenter
    WordWrap = True
  end
  object btnConnect: TButton
    Left = 40
    Top = 79
    Width = 145
    Height = 25
    Caption = 'Connect Scale'
    TabOrder = 0
    OnClick = btnConnectClick
  end
  object edtIP: TEdit
    Left = 83
    Top = 8
    Width = 121
    Height = 22
    TabOrder = 1
    Text = '192.168.8.210'
    OnKeyPress = edtIPKeyPress
  end
  object btnDownLoadData: TButton
    Left = 40
    Top = 118
    Width = 145
    Height = 25
    Caption = 'DownLoad Data'
    TabOrder = 2
    OnClick = btnDownLoadDataClick
  end
  object btnUploadData: TButton
    Left = 40
    Top = 149
    Width = 145
    Height = 25
    Caption = 'upload data'
    TabOrder = 3
    OnClick = btnUploadDataClick
  end
  object Button1: TButton
    Left = 227
    Top = 79
    Width = 169
    Height = 25
    Caption = 'Clear PLU'
    TabOrder = 4
    OnClick = Button1Click
  end
  object btnDownLoadPlu: TButton
    Left = 227
    Top = 128
    Width = 169
    Height = 25
    Caption = 'DownLoad PLU && HotKey'
    TabOrder = 5
    OnClick = btnDownLoadPluClick
  end
  object btnUploadPLU: TButton
    Left = 227
    Top = 159
    Width = 169
    Height = 25
    Caption = 'Upload PLU'
    Default = True
    TabOrder = 6
    OnClick = btnUploadPLUClick
  end
  object btnUpdatePrice: TButton
    Left = 227
    Top = 206
    Width = 169
    Height = 25
    Caption = 'Update Price'
    TabOrder = 7
    OnClick = btnUpdatePriceClick
  end
  object btnDownloadNutrition: TButton
    Left = 427
    Top = 118
    Width = 150
    Height = 25
    Caption = 'download Nutrition'
    TabOrder = 8
    OnClick = btnDownloadNutritionClick
  end
  object edtNutriName: TEdit
    Left = 619
    Top = 30
    Width = 121
    Height = 22
    TabOrder = 9
    Text = 'NutriName'
  end
  object btnHead: TButton
    Left = 429
    Top = 165
    Width = 150
    Height = 25
    Caption = 'DownLoad Ad Head'
    TabOrder = 10
    OnClick = btnHeadClick
  end
  object btnTail: TButton
    Left = 427
    Top = 196
    Width = 150
    Height = 25
    Caption = 'DownLoad Ad Tail'
    TabOrder = 11
    OnClick = btnTailClick
  end
  object btnUploadSaleData: TButton
    Left = 229
    Top = 394
    Width = 185
    Height = 25
    Caption = 'Upload Sale Data'
    TabOrder = 12
    OnClick = btnUploadSaleDataClick
  end
  object btnDownloadMsg: TButton
    Left = 227
    Top = 237
    Width = 169
    Height = 25
    Caption = 'Download Message'
    TabOrder = 13
    OnClick = btnDownloadMsgClick
  end
  object btnUpAdHead: TButton
    Left = 429
    Top = 234
    Width = 150
    Height = 25
    Caption = 'Upload Ad Head'
    TabOrder = 14
    OnClick = btnUpAdHeadClick
  end
  object btnUpAdTail: TButton
    Left = 429
    Top = 273
    Width = 150
    Height = 25
    Caption = 'Upload Ad Tail'
    TabOrder = 15
    OnClick = btnUpAdTailClick
  end
  object Button8: TButton
    Left = 227
    Top = 290
    Width = 169
    Height = 25
    Caption = 'Upload Message'
    TabOrder = 16
    OnClick = Button8Click
  end
  object btnDownloadDiscount: TButton
    Left = 227
    Top = 321
    Width = 169
    Height = 25
    Caption = 'download DisCount'
    TabOrder = 17
    OnClick = btnDownloadDiscountClick
  end
  object btnUploadDiscount: TButton
    Left = 227
    Top = 356
    Width = 169
    Height = 25
    Caption = 'upload DisCount'
    TabOrder = 18
    OnClick = btnUploadDiscountClick
  end
  object btnWeightUnit: TButton
    Left = 427
    Top = 77
    Width = 150
    Height = 30
    Caption = 'Download WeightUnit'
    TabOrder = 19
    OnClick = btnWeightUnitClick
  end
  object Button13: TButton
    Left = 231
    Top = 464
    Width = 185
    Height = 25
    Caption = 'Get Weight'
    TabOrder = 20
    OnClick = Button13Click
  end
  object btnCustomBar: TButton
    Left = 230
    Top = 433
    Width = 185
    Height = 25
    Caption = 'Download Custom barcode'
    TabOrder = 21
    OnClick = btnCustomBarClick
  end
  object btnUpgradeFirm: TButton
    Left = 619
    Top = 110
    Width = 160
    Height = 25
    Caption = 'Upgrade firmware'
    TabOrder = 22
    OnClick = btnUpgradeFirmClick
  end
  object edtPort: TEdit
    Left = 83
    Top = 36
    Width = 121
    Height = 22
    ImeName = #20013#25991'('#31616#20307') - '#25628#29399#20116#31508#36755#20837#27861
    TabOrder = 23
    Text = '0'
    OnKeyPress = edtPortKeyPress
  end
  object btnDownDept: TButton
    Left = 429
    Top = 311
    Width = 150
    Height = 25
    Caption = 'Download Department'
    TabOrder = 24
    OnClick = btnDownDeptClick
  end
  object btnUploadDept: TButton
    Left = 429
    Top = 342
    Width = 150
    Height = 25
    Caption = 'Upload Department'
    TabOrder = 25
    OnClick = btnUploadDeptClick
  end
  object Button2: TButton
    Left = 38
    Top = 236
    Width = 147
    Height = 26
    Caption = 'Generate font'
    TabOrder = 26
    OnClick = Button2Click
  end
  object cboxFontWeight: TComboBox
    Left = 126
    Top = 291
    Width = 95
    Height = 23
    Hint = 'Weight'
    Style = csDropDownList
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Times New Roman'
    Font.Style = []
    ItemIndex = 4
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 27
    Text = 'NORMAL'
    Items.Strings = (
      'DON'#39'T CARE'
      'THIN'
      'ULTRALIGHT'
      'LIGHT'
      'NORMAL'
      'MEDIUM'
      'SEMIBOLD'
      'BOLD'
      'ULTRABOLD'
      'HEAVY')
  end
  object btnCharset: TButton
    Left = 126
    Top = 325
    Width = 81
    Height = 25
    Caption = 'Charset'
    TabOrder = 28
    OnClick = btnCharsetClick
  end
  object edtFontCharset: TEdit
    Left = 45
    Top = 325
    Width = 65
    Height = 22
    ReadOnly = True
    TabOrder = 29
    Text = '1'
  end
  object btnCreateBoldFnt: TButton
    Left = 38
    Top = 367
    Width = 183
    Height = 25
    Caption = 'Create Bold Font'
    TabOrder = 30
    OnClick = btnCreateBoldFntClick
  end
  object downloadCustomFont: TButton
    Left = 27
    Top = 472
    Width = 181
    Height = 25
    Caption = 'Download Custom Font'
    ImageAlignment = iaRight
    TabOrder = 31
    OnClick = downloadCustomFontClick
  end
  object btnDownloadExchangeRate: TButton
    Left = 433
    Top = 526
    Width = 169
    Height = 25
    Caption = 'Download Exchange Rate'
    TabOrder = 32
    Visible = False
    OnClick = btnDownloadExchangeRateClick
  end
  object btnSetTransBreak: TButton
    Left = 40
    Top = 196
    Width = 145
    Height = 25
    Caption = 'Interrupt'
    TabOrder = 33
    OnClick = btnSetTransBreakClick
  end
  object Button3: TButton
    Left = 433
    Top = 570
    Width = 165
    Height = 25
    Caption = 'Download Vender'
    TabOrder = 34
    Visible = False
    OnClick = Button3Click
  end
  object Button6: TButton
    Left = 619
    Top = 79
    Width = 145
    Height = 25
    Caption = 'Check FirmwareVer'
    TabOrder = 35
    OnClick = Button6Click
  end
  object Button12: TButton
    Left = 433
    Top = 464
    Width = 167
    Height = 25
    Caption = 'download PacketType'
    TabOrder = 36
    OnClick = Button12Click
  end
  object Button14: TButton
    Left = 433
    Top = 495
    Width = 165
    Height = 25
    Caption = 'upload PacketType'
    TabOrder = 37
    OnClick = Button14Click
  end
  object btnUploadCustomHotkey: TButton
    Left = 433
    Top = 373
    Width = 169
    Height = 25
    Caption = 'upload Custom hotkey'
    TabOrder = 38
    OnClick = btnUploadCustomHotkeyClick
  end
  object Button15: TButton
    Left = 433
    Top = 415
    Width = 169
    Height = 25
    Caption = 'download IM'
    TabOrder = 39
    OnClick = Button15Click
  end
  object btnGenOtherFnt: TButton
    Left = 36
    Top = 398
    Width = 164
    Height = 26
    Caption = 'Generate other font'
    TabOrder = 40
    OnClick = btnGenOtherFntClick
  end
  object btnDownloadOtherFnt: TButton
    Left = 36
    Top = 430
    Width = 164
    Height = 26
    Caption = 'Download other font'
    TabOrder = 41
    OnClick = btnDownloadOtherFntClick
  end
  object Button19: TButton
    Left = 619
    Top = 180
    Width = 164
    Height = 25
    Caption = 'Get Printer info'
    TabOrder = 42
    Visible = False
    OnClick = Button19Click
  end
  object Button28: TButton
    Left = 692
    Top = 260
    Width = 117
    Height = 25
    Caption = 'Delete plu'
    TabOrder = 43
    Visible = False
    OnClick = Button28Click
  end
  object edtPlu: TEdit
    Left = 619
    Top = 261
    Width = 67
    Height = 22
    NumbersOnly = True
    TabOrder = 44
    Text = '1'
    Visible = False
  end
  object Button29: TButton
    Left = 619
    Top = 211
    Width = 155
    Height = 25
    Caption = 'Other Function'
    TabOrder = 45
  end
  object Button4: TButton
    Left = 619
    Top = 141
    Width = 174
    Height = 25
    Caption = 'Upload Firmware Version'
    TabOrder = 46
    Visible = False
    OnClick = Button4Click
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = 'hex'
    Filter = 'Binary Files|*.hex|All Files|*.*'
    InitialDir = '.'
    Options = [ofHideReadOnly, ofPathMustExist, ofFileMustExist]
    Title = 'Update!'
    Left = 168
    Top = 295
  end
  object FontDialog1: TFontDialog
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = #23435#20307
    Font.Style = []
    Left = 840
    Top = 271
  end
  object IdTCPClient1: TIdTCPClient
    IOHandler = IdIOHandlerStack1
    ConnectTimeout = 0
    IPVersion = Id_IPv4
    Port = 0
    ReadTimeout = -1
    Left = 800
    Top = 528
  end
  object IdIOHandlerStack1: TIdIOHandlerStack
    MaxLineAction = maException
    Port = 0
    DefaultPort = 0
    Left = 776
    Top = 408
  end
end
