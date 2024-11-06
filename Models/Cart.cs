using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63134295.Models
{
    public class CartItem
    {
        public GoiTap _goitap { get; set; }
        public int _goitap_soluong { get; set; }
        public int MaGoi { get; set; }


    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(GoiTap _gt, int _sl = 1)
        {
            var item = items.FirstOrDefault(s => s._goitap.MaGoi == _gt.MaGoi);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _goitap = _gt,
                    _goitap_soluong = _sl
                });
            }
            else
            {
                item._goitap_soluong += _sl;
            }
        }
        public void Update_Soluong(int id, int soluong)
        {
            var item = items.Find(s => s._goitap.MaGoi == id.ToString());
            if (item != null)
            {
                item._goitap_soluong = soluong;
            }
        }
        public double Total()
        {
            double total = 0;
            foreach (var item in items)
            {
                int maGoi;
                bool parseSuccess = int.TryParse(item._goitap.MaGoi.ToString(), out maGoi);
                if (parseSuccess)
                {
                    total += maGoi * item._goitap_soluong;
                }
            }
            return total;
        }
        public void Remove(int id)
        {
            items.RemoveAll(s => s._goitap.MaGoi == id.ToString());
        }
        public int Tong_SL()
        {
            return items.Sum(s => s._goitap_soluong);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}