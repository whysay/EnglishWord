using System;
using System.IO;

namespace EnglishWords
{
	/// <summary>
	/// Config에 대한 요약 설명입니다.
	/// </summary>
	public class Config
	{
		public string DefaultFileName;
		public int[] nTimeInterval = new int[]{4, 6};	//시간간격 (단어보여주는시간, 뜻 보여주는시간)
		public bool bAutoScroll = true;
		public bool bAlwaysOnTop = false;
        public bool bRead = false;
        public float fFontSize = 10F;
		public Config()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
			cIni iniFile = new cIni(".\\Config.ini");
            if (File.Exists(".\\Config.ini"))
            {
                nTimeInterval[0] = Int32.Parse(iniFile.ReadValue("Setting", "WordShowTime"));
                nTimeInterval[1] = Int32.Parse(iniFile.ReadValue("Setting", "MeanShowTime"));
                DefaultFileName = iniFile.ReadValue("Setting", "DefaultFileName");
                bAutoScroll = Boolean.Parse(iniFile.ReadValue("Setting", "AutoScroll"));
                bAlwaysOnTop = Boolean.Parse(iniFile.ReadValue("Setting", "AlwaysOnTop"));
                bRead = Boolean.Parse(iniFile.ReadValue("Setting", "Read"));
                fFontSize = float.Parse(iniFile.ReadValue("Setting", "FontSize"));
            }
            else
            {
                nTimeInterval[0] = 5;
                nTimeInterval[1] = 5;
                DefaultFileName = "word.txt";
                bAutoScroll = true;
                bAlwaysOnTop = true;
                fFontSize = 10F;
            }
			
		}

		public int GetWordTime()
		{
			return (nTimeInterval[0]*1000);
		}

		public int GetMeanTime()
		{
			return (nTimeInterval[1]*1000);
		}

		public void SaveConfigToFile()
		{
			cIni iniFile = new cIni(".\\Config.ini");
			iniFile.WriteValue("Setting", "WordShowTime", nTimeInterval[0].ToString());
			iniFile.WriteValue("Setting", "MeanShowTime", nTimeInterval[1].ToString());
			iniFile.WriteValue("Setting", "DefaultFileName", DefaultFileName);
			iniFile.WriteValue("Setting", "AutoScroll", bAutoScroll.ToString());
			iniFile.WriteValue("Setting", "AlwaysOnTop", bAlwaysOnTop.ToString());
            iniFile.WriteValue("Setting", "Read", bRead.ToString());
            iniFile.WriteValue("Setting", "FontSize", fFontSize.ToString());
		}
	}
}
