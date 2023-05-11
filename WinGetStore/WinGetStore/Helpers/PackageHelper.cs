﻿using AppInstallerCaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Management.Deployment;

namespace WinGetStore.Helpers
{
    public class PackageHelper
    {
        public static async Task<IEnumerable<Package>> FindPackagesByName(string PackageName)
        {
            await ThreadSwitcher.ResumeBackgroundAsync();
            PackageManager manager = new();
            try
            {
                IEnumerable<Package> packages = manager.FindPackagesForUser("");
                IEnumerable<Package> results = packages?.Where((x) => x.Id.FamilyName.StartsWith(PackageName));
                return results ?? Array.Empty<Package>();
            }
            catch
            {
                return Array.Empty<Package>();
            }
        }

        public static async Task<Package> FindPackagesByFamilyName(string PackageFamilyName)
        {
            await ThreadSwitcher.ResumeBackgroundAsync();
            PackageManager manager = new();
            try
            {
                return manager.FindPackageForUser("", PackageFamilyName);
            }
            catch
            {
                return null;
            }
        }
    }
}
