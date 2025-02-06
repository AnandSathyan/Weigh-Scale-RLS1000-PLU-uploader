unit addInfoForm;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TfrmAddInfo = class(TForm)
    Memo1: TMemo;
    btnok: TButton;
    btnCancel: TButton;
    procedure btnokClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure btnCancelClick(Sender: TObject);
  private
    { Private declarations }
  public
    AddInfo:AnsiString;
    { Public declarations }
  end;

var
  frmAddInfo: TfrmAddInfo;

implementation

{$R *.dfm}

procedure TfrmAddInfo.btnCancelClick(Sender: TObject);
begin
  self.ModalResult := mrcancel;
end;

procedure TfrmAddInfo.btnokClick(Sender: TObject);
begin
   AddInfo := Memo1.Lines.Text;
   self.ModalResult := mrok;
end;

procedure TfrmAddInfo.FormShow(Sender: TObject);
begin
   AddInfo := '';
end;

end.
