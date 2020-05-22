using Microsoft.AspNet.Identity.EntityFramework;
using MiniWS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext()
        : base("AppDb", throwIfV1Schema: false)
    {
    }
    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
}
