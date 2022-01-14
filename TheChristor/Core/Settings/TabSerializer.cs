using System;
using System.Collections.Generic;
using TheChristor.Core.Content;
namespace TheChristor.Core.Settings {
    public class TabSerializer : Serializer<TabSerializer> {
        protected override string StreamName
            => "data.xml";
        public TabSerializer() => Tabs = new List<TabInfo>();
        public TabSerializer(Boolean isDeserialize) : base(isDeserialize) {}
        public List<TabInfo> Tabs { get; set; } = new List<TabInfo>();
        protected override void SetValuesByDeserializeObject(TabSerializer deserializedObject)
            => Tabs = deserializedObject.Tabs; 
    }
}