<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/F1-Guy/zeaploy">
    <img src="https://am3pap004files.storage.live.com/y4mNksIegkSmF9PnEdl8dHRO7uRKOJ6rI6f_DauvL6HtrSKr4M1Qqt-tF49k0FL7uSmnA0yaSWn-JD4Bo8_a8vn44WWKbdVyTzlYX5dtDlDdYBwizcno89bEhMSzC5X4AwJlHj1pM5o3ULYZTcGRxpFtObywKbuZpdZ-HqRKxNXN2rnjBoXU04Y2z2Bd0OOOAffIjzmSv2JZ5PU49zmwDpRv8V2c5FOc_va7y3UaHfgRD4?encodeFailures=1&width=1852&height=656" alt="Logo" width="250" height="100">
  </a>

<h3 align="center">ZeaPloy</h3>

  <p align="center">
    Simple web application built with ASP.NET Core for the first year final project, made by students of Zealand Academy 
    <br />
    <a href="https://github.com/F1-Guy/zeaploy"><strong>Explore the code »</strong></a>
    <br />
    <br />
    <a href="https://github.com/F1-Guy/zeaploy">View Demo</a>
    ·
    <a href="https://github.com/F1-Guy/zeaploy/issues">Report Bug</a>
    ·
    <a href="https://github.com/F1-Guy/zeaploy/issues">Request Feature</a>
  </p>
</div>


<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://github.com/F1-Guy/zeaploy)

<p>
  This is an end of the first semester project based on the requirements set by the project document. 
  Our aim was to validate and utilize the skills and knowledge we have gained during the two semesters we have been tasked with designing, 
  planning, and implementing a .NET Core system. 
  The goal of this project is to enable each member of our group to fully understand the process and goals of application development in a real-world scenario. 
  From the inception stage all the way to planning, development and finally to testing and release. 
  Our aim is for each member of the group to be fully familiar with the skills needed for each step in this project and be able to apply modern methods and techniques that 
  are relevant and necessary to deliver a high-quality product. 
</p>

<p align="right">(<a href="#top">back to top</a>)</p>


### Built With

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
* [Entity Framework](https://entityframework.net/)
* [Azure Services](https://azure.microsoft.com/en-us/services/)
* [Bootstrap](https://getbootstrap.com)

<p align="right">(<a href="#top">back to top</a>)</p>

## Getting Started
### Prerequisites

<p>
  Requires .NET 6.0 or higher to run inside the IDE. Visual studio 2022 is highly recommended. 
</p>
<p>
  To work on the application you need to also connect to the database. Request a database login from project creators.
</p>

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/F1-Guy/zeaploy
   ```
2. Install the necessary NuGet packages if they are not installed automaticaly
    * []()Microsoft.EntityFrameworkCore 6.0.4
    * []()Microsoft.EntityFrameworkCore.Tools 6.0.4
    * []()Microsoft.EntityFrameworkCore.SqlServer 6.0.4
    * []()Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.4
    * []()AspNetCoreHero.ToastNotification 1.1.0
    * []()Castle.Windsor 5.1.1
    
3. Enter your connection string in `secrets.json`
   ```json
    {
      "ConnectionStrings:ZeaployConnection": "Data Source=ENTER CONNECTION STRING"
    }
   ```

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the Mozilla Public License Version 2.0. See `License.md` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- CONTACT -->
## Contact

Bartol Cagalj -  bart0707@edu.zealand.dk

Szymon Zwara - szym0277@edu.zealand.dk

Digna Bringule - dign0009@edu.zealand.dk

Tea Koscina - teax0669@edu.zealand.dk

Project Link: [https://github.com/F1-Guy/zeaploy](https://github.com/F1-Guy/zeaploy)

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* []()Mohammed El Allali
* []()Ivan Rosenvinge Frederiksen
* []()Nilma Abbas

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo_name.svg?style=for-the-badge
[contributors-url]: https://github.com/F1-Guy/zeaploy/graphs/contributors
[product-screenshot]: https://am3pap004files.storage.live.com/y4mVVbErE-UkrW5wEstsHkTUBrPv-Rvi5iSH8NLZHN8a-KzhrxtEyeEozNw1zlWv-soMG5yjdYwkDfQ4UpSKuMJRFIodpy7Ovl5zjD4xOBAmqrepLjUjw_dQ6mw90ZrGLOJMxUWO94sjq_Q3QwEm0l4azIY_w76ZICa1MHP_hLv1tseC8FqmSpLCumwzpoJUaIR8oSNlficlchPhsJyUkzSzJbKZuqI128ZRF-qS7rMNQk?encodeFailures=1&width=607&height=298
