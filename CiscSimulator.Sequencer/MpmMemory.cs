using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace CiscSimulator.Sequencer
{
    public class MpmMemory : UserControl
    {
        private Label labelMpmMemory;
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
                new MpmData(0x00000060E3),
                new MpmData(0x0000006747),
                new MpmData(0x0000006626),
                new MpmData(0x408A8C30E0),
                new MpmData(0x208B0060E3),
                new MpmData(0x108B0060E3),
                new MpmData(0x0000000000),
                new MpmData(0x108A843090),
                new MpmData(0x0A0B0060E3),
                new MpmData(0x408A8C30B0),
                new MpmData(0x120A8430B0),
                new MpmData(0x0A0B0070E3),
                new MpmData(0x0C0A8CA184),
                new MpmData(0x0000006265),
                new MpmData(0x090980A184),
                new MpmData(0x0000006265),
                new MpmData(0x090A84A184),
                new MpmData(0x0000006265),
                new MpmData(0x408A8C3140),
                new MpmData(0x210A84A184),
                new MpmData(0x0000006265),
                new MpmData(0x2088804C60),
                new MpmData(0x388980C170),
                new MpmData(0x0000066C60),
                new MpmData(0x3A09A0C170),
                new MpmData(0x0000066C60),
                new MpmData(0x3A69A0C170),
                new MpmData(0x0000066C60),
                new MpmData(0x3A68206C61),
                new MpmData(0x0000000000),
                new MpmData(0x3A11A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x3A19A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x3A21A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x088980C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0229A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x5A09A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x6209A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0239A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0231A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0241A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0249A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0251A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0259A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0261A0C170),
                new MpmData(0x0000064C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A0B804C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0909983560),
                new MpmData(0x0A8A866C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A8A8435A0),
                new MpmData(0x0A08906C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A0B0025E0),
                new MpmData(0x0C099835E0),
                new MpmData(0x288A8635E0),
                new MpmData(0x388B806C60),
                new MpmData(0x6C0B806C60),
                new MpmData(0x0000000000),
                new MpmData(0x000000F620),
                new MpmData(0x0000006C60),
                new MpmData(0x000000E620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000015620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000014620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000010620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000011620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000012620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000013620),
                new MpmData(0x0000006C60),
                new MpmData(0x0000286C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000306C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000386C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000406C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000486C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000506C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000586C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000606C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000686C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000706C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000006C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A8A843A00),
                new MpmData(0x0A0B906C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A8A843A40),
                new MpmData(0x0A0B903A40),
                new MpmData(0x0A8A843A40),
                new MpmData(0x0A0C906C60),
                new MpmData(0x0000786C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0000016C00),
                new MpmData(0x0000006AC0),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0C09983B00),
                new MpmData(0x0A8A866C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A8A843B40),
                new MpmData(0x0A0B906C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0D09983B00),
                new MpmData(0x0A8A866C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0A8A843B40),
                new MpmData(0x0A0C906C60),
                new MpmData(0x0000000000),
                new MpmData(0x0000000000),
                new MpmData(0x0D09983C00),
                new MpmData(0x0A8A863C00),
                new MpmData(0x0C09983C00),
                new MpmData(0x0A8A863C00),
                new MpmData(0x0C8A843C00),
                new MpmData(0x0A0B806000),
                new MpmData(0x0000016C00),
                new MpmData(0x0000006000)
            };
        }

        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            this.labelMpmMemory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMpmMemory
            // 
            this.labelMpmMemory.AutoSize = true;
            this.labelMpmMemory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMpmMemory.Location = new System.Drawing.Point(29, 57);
            this.labelMpmMemory.Name = "labelMpmMemory";
            this.labelMpmMemory.Size = new System.Drawing.Size(94, 19);
            this.labelMpmMemory.TabIndex = 1;
            this.labelMpmMemory.Text = "MpmMemory";
            // 
            // MpmMemory
            // 
            this.Controls.Add(this.labelMpmMemory);
            this.Name = "MpmMemory";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
