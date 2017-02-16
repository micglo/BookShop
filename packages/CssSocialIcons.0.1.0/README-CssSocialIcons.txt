The author of the Zocial icons is Sam Collins, I merely modified
the CSS to include a Microsoft icon as well and created the 
NuGet package.

One application of this package is in the ASP.NET Account Controller
with external login providers enabled (Google, Microsoft, Facebook,
Twitter, etc.). In this scenario you would bundle ~/Content/zocial.css
in the pages that would display such icons. For example I bundle it
in the ~/Content/css style bundle but you have to do that manually.
