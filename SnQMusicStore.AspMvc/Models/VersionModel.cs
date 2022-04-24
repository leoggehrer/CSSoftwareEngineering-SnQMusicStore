//@CodeCopy
//MdStart
using System;
using System.Text;

namespace SnQMusicStore.AspMvc.Models
{
    public class VersionModel : IdentityModel, Contracts.IVersionable
	{
		public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Gets and sets the the row stamp as string.
        /// </summary>
        public string RowVersionString
        {
            get
            {
                StringBuilder sb = new();

                if (RowVersion != null)
                {
                    foreach (var item in this.RowVersion)
                    {
                        if (sb.Length > 0)
                            sb.Append('.');

                        sb.Append((int)item);
                    }
                }
                return sb.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    string[] data = value.Split('.');
                    Byte[] ts = new byte[data.Length];

                    for (int i = 0; i < data.Length; i++)
                    {
                        ts[i] = Convert.ToByte(data[i]);
                    }
                    RowVersion = ts;
                }
            }
        }
    }
}
//MdEnd
