using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Properties2XML.Props
{
    public class Properties : IDictionary<string, string>
    {
        private IDictionary<string, string> InnerDictionary { get; } = new Dictionary<string, string>();
        private string FileName { get; }
        private string[] Data { get; }

        public Properties(string fileName)
        {
            this.FileName = fileName;
            this.Data = File.ReadAllLines(fileName, System.Text.Encoding.UTF8);
            foreach (var line in Data)
            {
                var lineSplit = line.Split("=");
                var key = lineSplit[0];
                var val = string.Join("=", lineSplit.Skip(1));
                if (key == "") continue;
                InnerDictionary.Add(key, val);
            }
        }

        #region IDictionary
        public ICollection<string> Keys => InnerDictionary.Keys;

        public ICollection<string> Values => InnerDictionary.Values;

        public int Count => InnerDictionary.Count;

        public bool IsReadOnly => InnerDictionary.IsReadOnly;

        public string this[string key] { get => InnerDictionary[key]; set => InnerDictionary[key] = value; }

        public void Add(string key, string value) => InnerDictionary.Add(key, value);

        public bool ContainsKey(string key) => InnerDictionary.ContainsKey(key);

        public bool Remove(string key) => InnerDictionary.Remove(key);

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value) => InnerDictionary.TryGetValue(key, out value);

        public void Add(KeyValuePair<string, string> item) => InnerDictionary.Add(item);

        public void Clear() => InnerDictionary.Clear();

        public bool Contains(KeyValuePair<string, string> item) => InnerDictionary.Contains(item);

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex) => InnerDictionary.CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<string, string> item) => InnerDictionary.Remove(item);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => InnerDictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => InnerDictionary.GetEnumerator();
        #endregion
    }
}