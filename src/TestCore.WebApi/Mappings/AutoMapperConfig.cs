using System;
using System.Linq;
using AutoMapper;

namespace TestCore.WebApi.Mappings
{
    /// <summary>
    ///     config mapper
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cnf =>
            {
                var autoMapperProfileTypes =
                    AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(
                            a =>
                                a.GetTypes()
                                    .Where(p => typeof (Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract));
                var autoMapperProfiles = autoMapperProfileTypes.Select(p => (Profile) Activator.CreateInstance(p));
                foreach (var profile in autoMapperProfiles)
                    cnf.AddProfile(profile);
            });
            return config;
        }
    }
}