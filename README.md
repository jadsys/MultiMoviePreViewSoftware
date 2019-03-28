# MultiMoviePreViewSoftware
<br>

## 1. はじめに

　以下、MultiMoviePreViewSoftwareの導入・運用について記述致します。<br>

## 2. 概要

　MultiMoviePreViewSoftwareは、Windows10で動作するソフトウェアで、ローカルフォルダの複数の動画を、同期を取りながら同時に再生する機能を提供します。同期再生に必要な動画の開始時刻は、動画データベースシステムから合わせて取り出された動画情報ファイル（ffmpeg、MediaInfo等の動画解析・編集ツールにて取得可能）から参照します。統合/個別スライダーを配し、纏めて再生位置を変更することや、個別に再生位置を変更することが可能です。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/system_image01.png)

## 3.　システム要件
### 3.1. 実行環境
　実行環境のシステム要件について以下に示します。Windows10であればソフトウェアのみ配置することで実行が可能ですが、ディスプレイ解像度1600×900（画面比率16:9）以上のPCをご準備願います。

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/requirements01.png)

※1 弊社動作確認時のスペックを参考に掲載しております。再生動画数4までは、CPU張り付き、スローダウンが発生しないことは確認済みです。再生動画数5以上で安定的に動画を再生させたい場合は、上記より高スペックのPCをご準備下さい。<br>
※2 サポート対象として記載しておりませんが、Windows7、Windows8.1でも動作可能です。<br>
※3 1600×900未満の解像度でも動作しますが、画面が切れて表示されます。<br>

### 3.2. 開発環境
　開発環境のシステム要件について以下に示します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/requirements02.png)

※1 弊社開発時のスペックを参考に掲載しております。
 
### 3.3. 動画ファイル
　動画ファイルのシステム要件について以下に示します。

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/requirements03.png)

## 4. 導入手順

### 4.1 実行環境
#### 4.1.1プログラムの配置
 「\Release」フォルダ配下の「MultiMoviePreViewSoftware」をフォルダ毎、任意のフォルダにコピーします。<br>
 ※ unityのプログラムの実行自体は特にインストール作業は不要です。

### 4.2 開発環境
#### 4.2.1 unityのインストール
##### (1) unityのダウンロード
  以下より「version 2018.2.13」のUnityインストーラをダウンロードします。<br>
（最新版では未検証・動作不安定のため「version 2018.2.13f1」をダウンロード下さい）<br>
　**ダウンロードURL：**<https://unity3d.com/jp/get-unity/download/archive> <br>
　**ダウンロードファイル：** UnityDownloadAssistant-2018.2.13f1.exe

##### (2) インストール
　・UnityDownloadAssistant-2018.2.13f1.exeを起動します。<br>
　・Nextボタンを押下します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows01.png)

　・License Agreementの画面が出るので「I accept…」をチェックし、Nextボタンを押下します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows02.png)

　・「Choose Components」画面が表示されるので、必要なコンポーネントをチェックします。<br>
　　①「Unity 2018.2.13f1」が必須コンポーネントになります。<br>
　　②「Microsoft Visual Studio Community 2017」がPCにインストールされていない場合は、チェックして下さい。<br>
 　　（ソースコード編集に使用します）<br>
　　③Nextボタンを押下します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows03.png)

　・「Choose Download and Install locations」画面が表示されるので、インストールフォルダを選択し、Nextボタンを押下します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows04.png)

　・インストールが開始されます。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows05.png)

　・「Completing the Unity Setup」が表示されたらインストール完了です。<br>
 　　Finishボタンを押下し、ダイアログを終了します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows06.png)

#### 4.2.2 開発環境の起動
##### (1) プログラムの配置
「\UnityData」フォルダ配下の「MultiMoviePreViewSoftware」をフォルダ毎、任意のフォルダにコピーします。<br>
##### (2) 開発環境の起動
　・デスクトップのアイコンをダブルクリックし、Unityを起動します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows07.png)

　・右上部の「Open」アイコンをクリックします。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows08.png)

　・「Open existing project」画面が表示されるので（１）にて配置した「MultiMoviePreViewSoftware」フォルダを選択し、「フォルダーの選択」ボタンを押下します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows09.png)

　・以下のUnityEditorの画面が表示されれば、終了です。Scene、Script等、プログラム編集が可能になります。<br> 

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows10.png)

　・画面下部の「Project」ウィンドウの「Script」→「0. Common」を押下し、任意のスクリプトをダブルクリックし、「Visual Studio Community 2017」が起動することを確認します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows11.png)

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows12.png)

## 5.　使用方法
### 5.1 実行環境
#### 5.1.1 プログラム起動
##### (1) 事前準備
　・再生したい動画と、同名の動画情報ファイル（拡張子は「.txt」）を準備します。<br>
　　動画情報ファイルはfffmpeg、MediaInfo等の動画情報が取得できるツールにて取得可能です。<br>
　　動画情報ファイルの出力例を以下に示します。<br>
　
**【動画情報ファイル】**<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows13.png)

<br>
　　上記、赤枠で括った行を動画開始時刻として取得します。

　「creation_time   : 2018-10-18T10:17:16.000000Z」（yyyy-mm-ddThh:mm:ss.ssssssZ）<br>

<font color="Red">※上記の1行があればプログラムは動作するので、fffmpegやMedioInfoといったツールがない場合は、テキストファイルを手動で作成し、creation_timeと上記形式の時刻情報を1行に記載して下さい。開始時間を変更したい場合も同行の時刻情報を編集頂くことで変更可能です。<br></font>

##### (2) プログラム起動
　・4.1.1項にて配置したプログラムフォルダに移動し、「MultiMoviePreViewSoftware.exe」をダブルクリックします。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows14.png)

　・「Configuration」画面が表示されるので、「Play！」ボタンを押下します。<br>
　　動画選択画面が表示されます。Windowモードで起動したい場合「Windowed」にチェックを入れて下さい。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows15.png)

 
#### 5.1.2 動画選択画面

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows16.png)

**【入力項目】**<br>
　　・数字キー「１～８」：動画選択を行う。<br>
　　・Enterキー：動画再生を開始する。<br>

##### (1) 動画選択
　・数字キー「１～８」を押下します。<br>
　・「Open」ダイアログが表示されるので、再生したい動画を選択し、Enterキーを押下します。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows17.png)

　・「Open」ダイアログが表示されるので、再生したい動画を選択し、Enterキーを押下します。<br>
　　動画選択画面中央に選択した動画ファイル名と開始時刻が表示されます。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows18.png)

　・引き続き、数字キー「１～８」を押し、上記の動画選択を繰返します。　<br>
　　最大8個まで動画ファイルを選択可能です。<br>
　　一度選択した動画ファイルを選択し直したい場合は、同じ数字キーを押下し、再選択して下さい。<br>
　・選択した動画の動画情報ファイルがないなど、同時再生が出来ない場合、以下のエラーダイアログが表示されます。<br>
　　エラーダイアログが表示された場合は、エラーテキストに表示された事象を確認後、「OK」ボタンを押下し、事象を解消した後に再度ファイル選択を行って下さい。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows19.png)

##### (2) 再生開始
　・動画選択が終わったら、Enterキーを押下します。動画再生画面が表示されます。<br>
　・動画ファイル名が一つも表示されていない状態でのEnterキー押下は無視されます。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows20.png)

#### 5.1.3 動画再生画面
動画再生枠は左上から「１･･･８」の順で配置されます。<br>

![image](https://github.com/jadsys/MultiMoviePreViewSoftware/wiki/images/windows21.png)

**【入力項目】**<br>
　　・Pause/Playボタン：動画を一時停止/再生する。<br>
　　・Resetボタン：画面をリフレッシュし、最初から動画を再生する。<br>
　　・Single/ALLボタン：スライダー操作モードを切替える。<br>
　　・Exitボタン：プログラムを終了する。<br>
　　・統合スライダー/個別スライダー：動画の再生位置を変更する。<br>
　　・数字キー「１～８」：注視画面―通常画面の切替を行う。<br>

##### (1) 動画を一時停止/再生する
・左下部に表示されている「Pause」ボタンを押下することで一時停止します。<br>
　一時停止中はボタン表示が「Play」に切り替わります。再生を再開したい場合は同ボタンを再度押下します。<br>
・一時停止/再生は全ての動画を対象としております（個別の一時停止/再生には対応しておりません）。<br>

##### (2) 動画再生画面をリセットする
・動画を最初から再生させたい場合に使用します。<br>
・画面左下部に表示されている「Reset」ボタンを押下します。押下後、画面がリフレッシュされ、動画が最初から再生されます。<br>

##### (3) 纏めて動画再生位置を変更する
・画面下部の長いスライダー（統合スライダー）を操作することで全動画を纏めて再生位置を変更します。<br>
・統合スライダー操作が可能な状態では、各動画再生枠の個別スライダーは操作はできません。<br>

##### (4) 個別に動画再生位置を変更する
・画面右下部の「Single」ボタンを押下し、スライダー操作モードを個別用に変更します。<br>
　ボタンを押下すると、ボタン表示が「ALL」になり、統合スライダーのつまみが透明となり、統合スライダーは操作不可となりますが、個別のスライダーが操作可能となります。<br>
・スライダー操作モードを元に戻したい場合は、「ALL」ボタンを押下して切替えます。<br>
・個別スライダーによる再生位置変更は、統合スライダー操作には反映されません。<br>
　（統合スライダー操作時に全ての動画の再生時刻は揃えられます）<br>

##### (5) 注視画面に切替える/通常画面に戻す
・注視（拡大）したい動画番号に該当する数字キー「１～８」を押下します。押下すると注視画面に切り替わります。<br>
・音声コーデックに対応している場合は音声を再生します。<br>
・注視したい動画以外の動画は画面右側に縮小表示されます。<br>
・通常画面に戻したい場合は、同じ数字キーを押下します。<br>
・注視画面にて別の動画を注視したい場合は別の数字キーを押下します。<br>

##### (6) プログラム終了
・画面右下部の「Exit」ボタンを押下します。ボタンを押下するとプログラムが終了します。<br>

### 5.2 開発環境
開発環境でのプログラム修正については各種Unityマニュアル・参考書をご参照下さい。<br>
