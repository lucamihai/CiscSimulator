using System;
using System.Collections.Generic;

namespace CiscSimulator.Sequencer
{
    public class MpmMemory
    {
        private readonly List<MpmData> mpmDataList;

        public int MinimumAddress { get; } = 0;
        public int MaximumAddress { get; } = 150;

        public MpmData this[int address]
        {
            get
            {
                ValidateAddress(address);
                return mpmDataList[address];
            }
        }

        private void ValidateAddress(int address)
        {
            if (address < MinimumAddress)
            {
                throw new InvalidOperationException($"{nameof(address)} can't be smaller than {MinimumAddress}");
            }

            if (address > MaximumAddress)
            {
                throw new InvalidOperationException($"{nameof(address)} can't be bigger than {MaximumAddress}");
            }
        }

        public MpmMemory()
        {
            mpmDataList = new List<MpmData>
            {
                new MpmData(0x408A8A6011),
                new MpmData(0x0000006052),
                new MpmData(0x00000060D3),
                new MpmData(0x0000006737),
                new MpmData(0x0000006616),
                new MpmData(0x408A8C3050),
                new MpmData(0x208B0060D3),
                new MpmData(0x108B0060D3),
                new MpmData(0x108A843080),
                new MpmData(0x0A0B0060D3),
                new MpmData(0x408A8C30A0),
                new MpmData(0x120A8430A0),
                new MpmData(0x0A0B0070D3),
                new MpmData(0x0C0A8CA174),
                new MpmData(0x0000006255),
                new MpmData(0x090980A174),
                new MpmData(0x0000006255),
                new MpmData(0x090A84A174),
                new MpmData(0x0000006255),
                new MpmData(0x408A8C3130),
                new MpmData(0x210A84A174),
                new MpmData(0x0000006255),
                new MpmData(0x2088804950),
                new MpmData(0x388980C160),
                new MpmData(0x0000066950),
                new MpmData(0x3A09A0C160),
                new MpmData(0x0000066950),
                new MpmData(0x3A69A0C160),
                new MpmData(0x0000066950),
                new MpmData(0x3A68206951),
                new MpmData(0x0000000000),
                new MpmData(0x3A11A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x3A19A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x3A21A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x088980D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0229A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x5A09A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x6209A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0239A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0231A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0241A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0249A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0251A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0259A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0261A0D160),
                new MpmData(0x0000064950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A0B804950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0909983550),
                new MpmData(0x0A8A866950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A8A843590),
                new MpmData(0x0A08906950),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A0B0025D0),
                new MpmData(0x0C099835D0),
                new MpmData(0x288A8635D0),
                new MpmData(0x388B806950),
                new MpmData(0x6C0B806950),
                new MpmData(0x0000000000),
                new MpmData(0x000000F610),
                new MpmData(0x0000006950),
                new MpmData(0x000000E610),
                new MpmData(0x0000006950),
                new MpmData(0x0000015610),
                new MpmData(0x0000006950),
                new MpmData(0x0000014610),
                new MpmData(0x0000006950),
                new MpmData(0x0000010610),
                new MpmData(0x0000006950),
                new MpmData(0x0000011610),
                new MpmData(0x0000006950),
                new MpmData(0x0000012610),
                new MpmData(0x0000006950),
                new MpmData(0x0000013610),
                new MpmData(0x0000006950),
                new MpmData(0x0000286950),
                new MpmData(0x0000306950),
                new MpmData(0x0000386950),
                new MpmData(0x0000406950),
                new MpmData(0x0000486950),
                new MpmData(0x0000506950),
                new MpmData(0x0000586950),
                new MpmData(0x0000606950),
                new MpmData(0x0000686950),
                new MpmData(0x0000706950),
                new MpmData(0x0000006950),
                new MpmData(0x0A8A8437E0),
                new MpmData(0x0A0B906950),
                new MpmData(0x0A8A843800),
                new MpmData(0x0A0B903800),
                new MpmData(0x0A8A843800),
                new MpmData(0x0A0C906950),
                new MpmData(0x0000006950),
                new MpmData(0x00000168F0),
                new MpmData(0x0000006850),
                new MpmData(0x0C09983870),
                new MpmData(0x0A8A866950),
                new MpmData(0x0A8A843890),
                new MpmData(0x0A0B906950),
                new MpmData(0x0D09983870),
                new MpmData(0x0A8A866950),
                new MpmData(0x0A8A843890),
                new MpmData(0x0A0C906950),
                new MpmData(0x0D099838F0),
                new MpmData(0x0A8A8638F0),
                new MpmData(0x0C099838F0),
                new MpmData(0x0A8A8638F0),
                new MpmData(0x0C8A8438F0),
                new MpmData(0x0A0B806000),
                new MpmData(0x00000168F0),
                new MpmData(0000006000),
            };
        }

    }
}
