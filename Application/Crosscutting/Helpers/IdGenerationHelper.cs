﻿namespace Crosscutting.Helpers
{
    using System;
    using System.Linq;
    using System.Text;

    public static class IdGenerationHelper
    {
        public static string GenerateId(int length)
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(length)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
    }
}