using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using KelvinatorX.Code;
using System.Collections.Generic;
using static KelvinatorX.Code.Enums;
using Android.Support.V4.Widget;
using ActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Gms.Ads;
using Android.Widget;
using Android.Graphics;
using System;

namespace KelvinatorX
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        int menuId;
        IMenu Menu { get; set; }

        Dictionary<Units, Android.Support.V4.App.Fragment> fragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = 
                new ActionBarDrawerToggle(this, 
                drawer, 
                toolbar, 
                Resource.String.navigation_drawer_open, 
                Resource.String.navigation_drawer_close);

            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);


            GenerateFragments();

            MobileAds.Initialize(this.ApplicationContext, Sec.InitializeMobileAds);
            ConfigureAdBanner();

            Button btn = FindViewById<Button>(Resource.Id.button1);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("TEST");
        }

        private void GenerateFragments()
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.layH_main_container, new StartFragment());
            ft.AddToBackStack(null);
            ft.Commit();

            fragments = new Dictionary<Units, Android.Support.V4.App.Fragment>
            {
                { Units.Distance, new DistanceFragment() },
                { Units.Temperature, new TemperatureFragment() },
                { Units.Weight, new WeightFragment() },
                { Units.Volume, new VolumeFragment() },
                { Units.Time, new TimeFragment() }
            };
        }

        private void ConfigureAdBanner()
        {
            AdView ad = new AdView(ApplicationContext);
            AdRequest adRequest = null;

            var android_id = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            // USE TEST ADS IF RUNNING ON A DEV DEVICE
            if (android_id == Sec.SamsungA5 || android_id == Sec.MyDeviceEmulator)
            {
                ad.AdUnitId = Sec.TestAdUnitId;
                adRequest = new AdRequest.Builder().AddTestDevice(android_id).Build();
            }
            else
            {
                ad.AdUnitId = Sec.AdUnitId;
                adRequest = new AdRequest.Builder().Build();
            }

            ad.AdSize = AdSize.Banner;
            ad.SetBackgroundColor(Color.Black);

            LinearLayout ll = FindViewById(Resource.Id.layH_admob_container) as LinearLayout;
            ll.SetGravity(GravityFlags.Center);
            ll.AddView(ad);

            ad.LoadAd(adRequest);
            adRequest.Dispose();
        }


        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);


            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            Menu = menu;
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_about)
            {
                var ft = SupportFragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.layH_main_container, new AboutFragment());
                ft.Commit();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            menuId = item.ItemId;
            
            if (menuId == Resource.Id.nav_distance)
            {
                var ft = SupportFragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.layH_main_container, fragments[Units.Distance]);
                ft.Commit();
            }

            else if (menuId == Resource.Id.nav_temperature)
            {
                var ft = SupportFragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.layH_main_container, fragments[Units.Temperature]);
                ft.Commit();
            }
            else if (menuId == Resource.Id.nav_weight)
            {
                var ft = SupportFragmentManager.BeginTransaction();

                ft.Replace(Resource.Id.layH_main_container, fragments[Units.Weight]);
                ft.Commit();
            }
            else if (menuId == Resource.Id.nav_volume)
            {
                var ft = SupportFragmentManager.BeginTransaction();

                ft.Replace(Resource.Id.layH_main_container, fragments[Units.Volume]);
                ft.Commit();
            }
            else if (menuId == Resource.Id.nav_time)
            {
                var ft = SupportFragmentManager.BeginTransaction();

                ft.Replace(Resource.Id.layH_main_container, fragments[Units.Time]);
                ft.Commit();
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

