//After executing the above code, I was able to see the Logger messages appearing in Application Insights.

var queryPath = "https://xyz.crm8.dynamics.com/api/data/v9.2/organizations(8c4b5b8d-1241-ef11-8e4b-6045bde849d6)";
  var param = {};
  param["telemetryinstrumentationkey"] = "f435d825-fdd8-42b7-b201-c58fb626dc0b";

  var req = new XMLHttpRequest();
  req.open("PATCH", queryPath, true);
  req.setRequestHeader("OData-MaxVersion", "4.0");
  req.setRequestHeader("OData-Version", "4.0");
  req.setRequestHeader("Accept", "application/json");
  req.setRequestHeader("Content-Type", "application/json; charset=utf-8");

  req.onreadystatechange = function () {
           if (this.readyState === 4) {
               req.onreadystatechange = null;
               alert(this.status);
           }
       };
  req.send(JSON.stringify(param));