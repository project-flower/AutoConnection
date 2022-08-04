using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace AutoConnection
{
    public struct WindowParameters
    {
        #region Private Fields

        private const string CategoryOfButton = "ボタン";
        private const string CategoryOfDescription = "説明文";
        private const string CategoryOfPassword = "パスワード";
        private const string CategoryOfUser = "ユーザー名";
        private const string CategoryOfWindow = "ウィンドウ";
        private readonly static XmlSerializer serializer = new XmlSerializer(typeof(WindowParameters[]));

        #endregion

        #region Public Properties

        [Category(CategoryOfButton)]
        [Description("ボタンのクラス名を指定します。")]
        public string ButtonClassName { get; set; }
        [Category(CategoryOfButton)]
        [Description("ボタンのオブジェクト名を指定します。")]
        public string ButtonControlName { get; set; }
        [Category(CategoryOfButton)]
        [Description("ボタンのテキストを指定します。")]
        public string ButtonText { get; set; }
        [Category(CategoryOfDescription)]
        [Description("説明文のテキストを指定します。")]
        public string Description { get; set; }
        [Category(CategoryOfDescription)]
        [Description("説明文のクラス名を指定します。")]
        public string DescriptionClassName { get; set; }
        [Category(CategoryOfDescription)]
        [Description("説明文のオブジェクト名を指定します。")]
        public string DescriptionControlName { get; set; }
        [Category(CategoryOfPassword)]
        [Description("パスワード入力欄のクラス名を指定します。")]
        public string PasswordClassName { get; set; }
        [Category(CategoryOfPassword)]
        [Description("パスワード入力欄のオブジェクト名を指定します。")]
        public string PasswordControlName { get; set; }
        [Category(CategoryOfPassword)]
        [Description("パスワードを指定します。")]
        [PasswordPropertyText(true)]
        public string Password { get; set; }
        [Category(CategoryOfUser)]
        [Description("ユーザー名入力欄のクラス名を指定します。")]
        public string UserNameClassName { get; set; }
        [Category(CategoryOfUser)]
        [Description("ユーザー名入力欄のオブジェクト名を指定します。")]
        public string UserNameControlName { get; set; }
        [Category(CategoryOfUser)]
        [Description("ユーザー名を指定します。")]
        public string UserName { get; set; }
        [Category(CategoryOfWindow)]
        [Description("ウィンドウのタイトルを指定します。")]
        public string WindowTitle { get; set; }

        #endregion

        #region Public Methods

        public static WindowParameters[] LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                return serializer.Deserialize(stream) as WindowParameters[];
            }
        }

        public static WindowParameters[] Sample()
        {
            var parameters1 = new WindowParameters()
            {
                ButtonClassName = "Button",
                ButtonControlName = string.Empty,
                ButtonText = "OK",
                Description = "次に接続するための資格情報を入力してください: 127.0.0.1",
                DescriptionClassName = "TextBlock",
                DescriptionControlName = string.Empty,
                Password = "password",
                PasswordClassName = "PasswordBox",
                PasswordControlName = string.Empty,
                UserName = "user",
                UserNameClassName = "TextBox",
                UserNameControlName = string.Empty,
                WindowTitle = "Windows セキュリティ"
            };

            WindowParameters parameters2 = (WindowParameters)(parameters1.MemberwiseClone());
            parameters2.Description = "Connecting to 127.0.0.1";

            return new WindowParameters[]
            {
                parameters1, parameters2
            };
        }

        public static void SaveTo(string fileName, WindowParameters[] parameters)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, parameters);
            }
        }

        #endregion
    }
}
