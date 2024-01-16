// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
#pragma warning disable CS1591 // document public APIs

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters
{
    public sealed class SaveDataFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::SaveData>
    {
        // ItemBox
        private static global::System.ReadOnlySpan<byte> GetSpan_ItemBox() => new byte[1 + 7] { 167, 73, 116, 101, 109, 66, 111, 120 };
        // PickedItems
        private static global::System.ReadOnlySpan<byte> GetSpan_PickedItems() => new byte[1 + 11] { 171, 80, 105, 99, 107, 101, 100, 73, 116, 101, 109, 115 };
        // GameFlags
        private static global::System.ReadOnlySpan<byte> GetSpan_GameFlags() => new byte[1 + 9] { 169, 71, 97, 109, 101, 70, 108, 97, 103, 115 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::SaveData value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(3);
            writer.WriteRaw(GetSpan_ItemBox());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<int>>(formatterResolver).Serialize(ref writer, value.ItemBox, options);
            writer.WriteRaw(GetSpan_PickedItems());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<int>>(formatterResolver).Serialize(ref writer, value.PickedItems, options);
            writer.WriteRaw(GetSpan_GameFlags());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<global::GameFlag>>(formatterResolver).Serialize(ref writer, value.GameFlags, options);
        }

        public global::SaveData Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var ____result = new global::SaveData();

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 7:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 33899328299168841UL) { goto FAIL; }

                        ____result.ItemBox = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<int>>(formatterResolver).Deserialize(ref reader, options);
                        continue;
                    case 11:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_PickedItems().Slice(1))) { goto FAIL; }

                        ____result.PickedItems = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<int>>(formatterResolver).Deserialize(ref reader, options);
                        continue;
                    case 9:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_GameFlags().Slice(1))) { goto FAIL; }

                        ____result.GameFlags = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::System.Collections.Generic.List<global::GameFlag>>(formatterResolver).Deserialize(ref reader, options);
                        continue;

                }
            }

            reader.Depth--;
            return ____result;
        }
    }

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name
