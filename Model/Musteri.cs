using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.View
{
 public   class Musteri
    {
        public string MusteriAdi { get; set; }
        public string MusteriSoyad { get; set; }
        public string MusterAdres { get; set; }
        public string MusteriUser { get; set; }
        public string MusteriPassword { get; set; }
        public int Musteriid { get; set; }

        public Musteri(int id)
        {
             id = Musteriid;
            
        }

        public Musteri()
        {
        }
    }
}
