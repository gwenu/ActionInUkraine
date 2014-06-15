using System.Web.Optimization;
using ActionInUkraine.Web;

[assembly: WebActivator.PostApplicationStartMethod(
    typeof(DurandalConfig), "PreStart")]

namespace ActionInUkraine.Web
{
    public static class DurandalConfig
    {
        public static void PreStart()
        {
            // Add your start logic here
            DurandalBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}