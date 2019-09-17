namespace KopGelMarket.Migrations
{
    using KopGelMarket.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KopGelMarket.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KopGelMarket.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "admin" };
                roleManager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "admincetin@gmail.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    Email = "admincetin@gmail.com",
                    UserName = "admincetin@gmail.com",
                    Ad = "Çetin",
                    Soyad = "Uçar",
                    EmailConfirmed = true
                };
                userManager.Create(user, "Ankara1.");
                userManager.AddToRole(user.Id, "admin");
            }
            if (!context.Kategoriler.Any())
            {
                var kategori1 = new Kategori
                {
                    KategoriAd = "Ýçecekler"
                };
                var kategori2 = new Kategori
                {
                    KategoriAd = "Süt Ürünleri"
                };
                var kategori3 = new Kategori
                {
                    KategoriAd = "Telefonlar"
                };
                kategori1.Urunler.Add(new Urun
                {
                    UrunAd = "Kola",
                    BirimFiyat = 4.5m,
                    Aciklama = "Serinleten Lezzet"
                });
                kategori1.Urunler.Add(new Urun
                {
                    UrunAd = "Ice Tea",
                    BirimFiyat = 3.5m,
                    Aciklama = "Ferahlamak için en iyisi"
                });
                kategori2.Urunler.Add(new Urun
                {
                    UrunAd = "Ayran",
                    BirimFiyat = 2.5m,
                    Aciklama = "Milli Ýçeceðimiz"
                });
                kategori2.Urunler.Add(new Urun
                {
                    UrunAd = "Yoðurt",
                    BirimFiyat = 7m,
                    Aciklama = "Tamamen doðal lezzet"
                });
                kategori3.Urunler.Add(new Urun
                {
                    UrunAd = "Iphone X",
                    BirimFiyat = 8500m,
                    Aciklama = "Bir telefondan daha fazlasý"
                });
                kategori3.Urunler.Add(new Urun
                {
                    UrunAd = "Huawei Mate 20 Lite",
                    BirimFiyat = 2200m,
                    Aciklama = "Bu teknolojiye hayran kalacaksýnýz"
                });
                context.Kategoriler.Add(kategori1);
                context.Kategoriler.Add(kategori2);
                context.Kategoriler.Add(kategori3);
            }
            if (!context.Sehirler.Any())
            {
                foreach (KeyValuePair<int, string> entry in TurkiyeSehirler())
                {
                    context.Sehirler.Add(new Sehir
                    {
                          Id=entry.Key,
                           SehirAd=entry.Value,

                    });
                }
            }
        }

        private Dictionary<int, string> TurkiyeSehirler()
        {
            return new Dictionary<int, string>
            {
                    {1, "Adana"},
                    {2, "Adýyaman"},
                    {3, "Afyonkarahisar"},
                    {4, "Aðrý"},
                    {5, "Amasya"},
                    {6, "Ankara"},
                    {7, "Antalya"},
                    {8, "Artvin"},
                    {9, "Aydýn"},
                    {10, "Balýkesir"},
                    {11, "Bilecik"},
                    {12, "Bingöl"},
                    {13, "Bitlis"},
                    {14, "Bolu"},
                    {15, "Burdur"},
                    {16, "Bursa"},
                    {17, "Çanakkale"},
                    {18, "Çankýrý"},
                    {19, "Çorum"},
                    {20, "Denizli"},
                    {21, "Diyarbakýr"},
                    {22, "Edirne"},
                    {23, "Elazýð"},
                    {24, "Erzincan"},
                    {25, "Erzurum"},
                    {26, "Eskiþehir"},
                    {27, "Gaziantep"},
                    {28, "Giresun"},
                    {29, "Gümüþhane"},
                    {30, "Hakkari"},
                    {31, "Hatay"},
                    {32, "Isparta"},
                    {33, "Mersin"},
                    {34, "Ýstanbul"},
                    {35, "Ýzmir"},
                    {36, "Kars"},
                    {37, "Kastamonu"},
                    {38, "Kayseri"},
                    {39, "Kýrklareli"},
                    {40, "Kýrþehir"},
                    {41, "Kocaeli"},
                    {42, "Konya"},
                    {43, "Kütahya"},
                    {44, "Malatya"},
                    {45, "Manisa"},
                    {46, "Kahramanmaraþ"},
                    {47, "Mardin"},
                    {48, "Muðla"},
                    {49, "Muþ"},
                    {50, "Nevþehir"},
                    {51, "Niðde"},
                    {52, "Ordu"},
                    {53, "Rize"},
                    {54, "Sakarya"},
                    {55, "Samsun"},
                    {56, "Siirt"},
                    {57, "Sinop"},
                    {58, "Sivas"},
                    {59, "Tekirdað"},
                    {60, "Tokat"},
                    {61, "Trabzon"},
                    {62, "Tunceli"},
                    {63, "Þanlýurfa"},
                    {64, "Uþak"},
                    {65, "Van"},
                    {66, "Yozgat"},
                    {67, "Zonguldak"},
                    {68, "Aksaray"},
                    {69, "Bayburt"},
                    {70, "Karaman"},
                    {71, "Kýrýkkale"},
                    {72, "Batman"},
                    {73, "Þýrnak"},
                    {74, "Bartýn"},
                    {75, "Ardahan"},
                    {76, "Iðdýr"},
                    {77, "Yalova"},
                    {78, "Karabük"},
                    {79, "Kilis"},
                    {80, "Osmaniye"},
                    {81, "Düzce"}
            };

        }
    }
}
