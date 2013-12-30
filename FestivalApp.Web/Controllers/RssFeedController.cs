using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FestivalApp.Web.Controllers
{
    public class RssFeedController: ApiController
    {
        public static Rss20FeedFormatter GetFeed() {
            var feed = new SyndicationFeed("Festival", "Dit is een test feed voor de festival web applicatie", new Uri("http://festivalapp.be"));
            feed.Authors.Add(new SyndicationPerson("martijn.werbrouck@student.howest.be"));
            feed.Categories.Add(new SyndicationCategory("Festival"));

            SyndicationItem item1 = new SyndicationItem(
                "Netsky",
                "Boris Daenen, beter bekend als Netsky, heeft een indrukwekkend jaar 2012 achter de rug!",
                new Uri("http://localhost:7764/LineUp/Details/2"),
                "2",
                DateTime.Now);

            SyndicationItem item2 = new SyndicationItem(
                "The Opposites",
                "De ene is heel lang en blank, de andere heel klein en donker. Vandaar de naam The Opposites. Toch hebben Willem de Bruin (Willy, die kleine donkere) en Twan van Steenhoven (Big2, die lange blanke) meer gemeen dan hun tegenovergestelde uiterlijk doet vermoeden.",
                new Uri("http://localhost:7764/LineUp/Details/1"),
                "1",
                DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();

            items.Add(item1);
            items.Add(item2);

            feed.Items = items;

            return new Rss20FeedFormatter(feed);
        }
    }
}
