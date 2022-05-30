using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMap.EntityCore
{
    public class EntityRepository : IEntity<Guid>
    {
        public EntityRepository()
        {
            Status = Status.Active;
        }


        public Guid ID { get; set; }

        public int? MasterId { get; set; }//opsiyonel
        public Status Status { get; set; } //verinin durumu



        //Veri eklendiğinde tutulacak bilgiler
        public DateTime? CreatedDate { get; set; }//oluşturma zamanı
        public string CreatedComputerName { get; set; }//bilgisayarın adı
        public string CreatedIP { get; set; }//ip no
        public string CreatedAdUsername { get; set; }//windows'da oturum açılan kullanıcı adı
        public string CreatedBy { get; set; }//kullanıcı adı



        //Veri güncellendiğinde tutulacak bilgiler

        public DateTime? UpdatedDate { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedIP { get; set; }
        public string UpdatedAdUsername { get; set; }
        public string UpdatedBy { get; set; }


        //todo: created ve updated propertyleri veritabanına kayıt esnasında doldurulacak. IP yakalama nesnesi oluşturulacak.
    }

}

