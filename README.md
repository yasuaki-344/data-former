# data-former

このツールはエクセルファイル上のデータを抽出して，
分析可能なフォーマットに変換するためのツールです．

## 使い方

### 設定ファイルの構成

* `input_file_path`: データ抽出元のエクセルファイルのパス
* `output_file_path`: 抽出, 整形したデータを書き込むエクセルファイルのパス
* `sheets`: 出力するエクセルファイルのシート情報のリスト
  * `sheet_name`: 作成するシート名
  * `header`: 列情報の設定リスト
    * `column_name`: 列名
    * `type`: データの型
  * `search_blocks`: データ探索範囲リスト, 列ごとに設定
    * `direction`: どちら（行, 列）から探索を開始するか
    * `row_size`: 行方向に取得するデータの数
    * `column_size`: 列方向に取得するデータの数
    * `column_search`: 列ごとに探索設定
      * `sheet_name`: 探索先のシート名
      * `initial_row`: 行の探索開始位置(1始まり, エクセルの行番号に対応)
      * `initial_column`: 列の探索開始位置(ex. AB)
      * `row_increment`: 行方向にデータを取得する間隔
      * `column_increment`: 列方向にデータを取得する間隔

### 対応データ型

* `integer`: 整数
* `decimal`: 実数
* `dateTime`: 日付と時刻
* `date`: 日付
* `time`: 時刻
* `label`: テキスト
* `boolean`: ブール値(trueもしくはfalse)
* `formula`: セルに埋め込まれた数式
* `comment`: セルに埋め込まれたコメント
