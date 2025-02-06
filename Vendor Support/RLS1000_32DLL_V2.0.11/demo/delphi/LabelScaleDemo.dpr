program LabelScaleDemo;

uses
  Forms,
  MainForm in 'MainForm.pas' {FrmMain},
  superobject in 'superobject.pas',
  uDllInterface in 'uDllInterface.pas',
  uGlobalFun in 'uGlobalFun.pas' {$R *.res},
  addInfoForm in 'addInfoForm.pas' {frmAddInfo};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFrmMain, FrmMain);
  Application.CreateForm(TfrmAddInfo, frmAddInfo);
  Application.Run;
end.
