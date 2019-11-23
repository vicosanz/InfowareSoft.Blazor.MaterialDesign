using System;
using System.Collections.Generic;
using System.Linq;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public class ClassMapper
    {
        private List<(Func<bool>, Func<string>)> _map = new List<(Func<bool>, Func<string>)>();
        public ClassMapper()
        {
        }

        public string Class
        {
            get => $"{string.Join(" ", _map.Where(x => x.Item1()).Select(y => y.Item2()))}";
        }

        public ClassMapper Add(string value)
        {
            _map.Add((() => true, () => value));
            return this;
        }
        public ClassMapper Variant(Func<string> value)
        {
            _map.Add((() => true, value));
            return this;
        }

        public ClassMapper If(Func<bool> cond, string value)
        {
            _map.Add((cond, ()=>value));
            return this;
        }
    }
}