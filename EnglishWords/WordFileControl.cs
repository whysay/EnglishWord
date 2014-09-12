using System;
using System.IO;
using System.Collections;

namespace EnglishWords
{
	/// <summary>
	/// WordFileControl에 대한 요약 설명입니다.
	/// </summary>
	public class WordFileControl
	{
		Form1 form1;
		public SortedList WordsSL = new SortedList();
		//SortedList MeaningSL = new SortedList();
		public ArrayList IndexAL = new ArrayList();
		public Random rand = new Random();
		public int nCurIndex = 0;
        public string filename;

		public WordFileControl(Form1 mainform)
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
			form1 = mainform;
		}

		public bool LoadNewFile(string FileName)
		{
			WordsSL.Clear();
			IndexAL.Clear();
			nCurIndex = 0;

            filename = FileName;
			if( File.Exists(FileName) == false )
			{
				return false;
			}

            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
			StreamReader r = new StreamReader(file, System.Text.Encoding.Default);
			int i = 0;
			int nRand = 0;
			while( r.Peek() >= 0 )
			{
                string str = r.ReadLine();

				if( IndexAL.Count != 0 )
				{
					nRand = rand.Next();
					if( nRand < 0 )
						nRand *= -1;
					nRand %= IndexAL.Count;
				}
                if (str[0] == '*')
                {
                    IndexAL.Insert(nRand, i);
                }

                WordsSL.Add(i, str);
                    
                i++;
			}
            file.Dispose();

			return true;
		}

		public string GetWord()
		{
            if( IndexAL.Count == 0 )
            {
                string str = "Error! Word Empty! / 오류! 단어가 없습니다!";
                return str;
            }

			if(IndexAL.Count <= nCurIndex)
				nCurIndex = 0;

			return (string)WordsSL.GetByIndex((int)IndexAL[nCurIndex++]);
		}

        public int GetItemCount()
        {
            return WordsSL.Count;
        }
	}
}
