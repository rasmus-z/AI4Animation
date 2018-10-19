# VRM PFNN ARKit Sample

ARKit で検出した水平面に対して PFNN が生成したモーションを VRM ファイルに反映するサンプルです。

##設定など
- UniVRM を使用しています。下記のリポジトリから unitypackage をダウンロードし、 Unity にインポートしてください。

https://github.com/dwango/UniVRM/releases

- Unity ARKit Plugin を使用しています。下記のリポジトリからダウンロードし、 Unity の Assets ディレクトリ下に配置してください。

https://bitbucket.org/Unity-Technologies/unity-arkit-plugin/downloads/?tab=tags

- パラメータファイルを読み込ませる必要があります。下記の zip ファイルを任意の場所に解凍して、 PFNN スクリプトの Folder 欄にパスを指定し、 Store Parameters ボタンで設定してください。

http://www.starke-consult.de/UoE/GitHub/SIGGRAPH_2017/NN_Original_PFNN.zip

## 注意事項
- 学習済みのデータに合わせるため、サンプルではボーンをわざと歪めている部分があります。自前のデータと差し替える際はご注意ください。

- iOS 用の Eigen ライブラリは bitcode を無効にしています。 Xcode 上で bitcode の設定を合わせるか、またはライブラリを再生成してください。 Plugins ディレクトリ下にライブラリの生成に使用したコマンドファイルを置いてあります。

