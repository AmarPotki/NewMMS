namespace Framework
{
	public static class String
	{
		static String()
		{
		}

		public static string? Fix(string text)
		{
			if (text is null)
			{
				return null;
			}

			text = text.Trim();

			if (text == string.Empty)
			{
				return null;
			}

			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}

		public static bool IsJustInt(string text)
		{
			if (text == null)
			{
				return (false);
			}

			if (text == string.Empty)
			{
				return (false);
			}

			try
			{
                Convert.ToInt32(text);

				return (true);
			}
			catch
			{
				return (false);
			}
		}

		public static bool IsJustLong(string text)
		{
			if (text == null)
			{
				return (false);
			}

			if (text == string.Empty)
			{
				return (false);
			}

			try
			{
				System.Convert.ToInt64(text);

				return (true);
			}
			catch
			{
				return (false);
			}
		}

	}
}
