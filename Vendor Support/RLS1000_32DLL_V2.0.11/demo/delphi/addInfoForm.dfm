object frmAddInfo: TfrmAddInfo
  Left = 0
  Top = 0
  Caption = 'Additional Information'
  ClientHeight = 312
  ClientWidth = 544
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poMainFormCenter
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Memo1: TMemo
    Left = 32
    Top = 8
    Width = 465
    Height = 217
    Lines.Strings = (
      'Memo1')
    MaxLength = 2048
    TabOrder = 0
  end
  object btnok: TButton
    Left = 96
    Top = 256
    Width = 75
    Height = 25
    Caption = 'Ok'
    TabOrder = 1
    OnClick = btnokClick
  end
  object btnCancel: TButton
    Left = 264
    Top = 256
    Width = 75
    Height = 25
    Caption = 'Cancel'
    TabOrder = 2
    OnClick = btnCancelClick
  end
end
