

/*
document.addEventListener("DOMContentLoaded", function(event) {
  // Your code here will run once the DOM is ready
 
//JS para tener un header y un footer dinamico a lo largo de las paginas
const header = document.querySelector("header");
const footer = document.querySelector("footer");

header.innerHTML = `
<nav>
      <div class="navbar">
        <i class='bx bx-menu'></i>
        <div class="logo"><a href="#">Sententia</a></div>
        <div class="nav-links">
          <div class="sidebar-logo">
            <span class="logo-name">Sententia</span>
            <i class='bx bx-x'></i>
          </div>
          <ul class="links">
            <li><a href="SententiaHome.html">HOME</a></li>
            <li><a href="#">Music</a></li>
            <li><a href="#">Discover</a></li>
            <li><a href="#">Lists</a></li>
            <li><a href="#">User</a></li>
            <li><a href="#">Login</a></li>
            <li>
              <a href="#">More</a>
              <i class='bx bxs-chevron-down js-arrow arrow '></i>
              <ul class="js-sub-menu sub-menu">
                <li><a href="#">Artist</a></li>
                <li><a href="#">Bands</a></li>
                <li><a href="#">Album</a></li>
                <li><a href="#">Songs</a></li>
              </ul>
            </li>
          </ul>
        </div>
        <div class="search-box">
          <i class='bx bx-search'></i>
          <div class="input-box">
            <input type="text" placeholder="Search...">
          </div>
        </div>
      </div>
    </nav>
`;

footer.innerHTML = `
<div class="footer-left">
      <h3>Sententia</h3>
      <p class="footer-links">
        <a href="SententiaHome.html" class="link-1">Home</a>
        <a href="#">Music</a>
        <a href="#">Discover</a>
        <a href="#">Lists</a>
      </p>
      <p class="footer-company-name">Sententia © 2024</p>
    </div>

    <div class="footer-center">
      <div>
        <p><a href="mailto:Sauldeleonn@hotmail.com">Sauldeleonn@hotmail.com</a></p>
        <br>
        <p><a href="mailto:Erick.aguilar.soto@gmail.com">Erick.aguilar.soto@gmail.com</a></p>
      </div>
    </div>

    <div class="footer-right">
      <p class="footer-company-about">
        <span>About Sententia</span>
        Named Sententia (Opinion in Latin). It's a platform where users can share their opinions on various
        music-related topics, including songs, albums, artists, and more.
      </p>
      <div class="footer-icons">
        <a href="https://www.linkedin.com/in/sauldeleonn" target="_blank"><i class="fa fa-linkedinSaul"></i></a>
        <a href="https://github.com/Sauldeleonn" target="_blank"><i class="fa fa-githubSaul"></i></a>
        <a href="#" target="_blank"><i class="fa fa-linkedinErick"></i></a>
        <a href="#" target="_blank"><i class="fa fa-githubErick"></i></a>
      </div>
    </div>
`;
*/



// search-box open close js code
let navbar = document.querySelector(".navbar");
let searchBox = document.querySelector(".search-box .bx-search");
// let searchBoxCancel = document.querySelector(".search-box .bx-x");

searchBox.addEventListener("click", ()=>{
  navbar.classList.toggle("showInput");
  if(navbar.classList.contains("showInput")){
    searchBox.classList.replace("bx-search" ,"bx-x");
  }else {
    searchBox.classList.replace("bx-x" ,"bx-search");
  }
});

// sidebar open close js code
let navLinks = document.querySelector(".nav-links");
let menuOpenBtn = document.querySelector(".navbar .bx-menu");
let menuCloseBtn = document.querySelector(".nav-links .bx-x");
menuOpenBtn.onclick = function() {
navLinks.style.left = "0";
}
menuCloseBtn.onclick = function() {
navLinks.style.left = "-100%";
}


// sidebar submenu open close js code
let htmlcssArrow = document.querySelector(".htmlcss-arrow");
htmlcssArrow.onclick = function() {
 navLinks.classList.toggle("show1");
}
let moreArrow = document.querySelector(".more-arrow");
moreArrow.onclick = function() {
 navLinks.classList.toggle("show2");
}
let jsArrow = document.querySelector(".js-arrow");
jsArrow.onclick = function() {
 navLinks.classList.toggle("show3");
}













/*
console.log("DOM is ready!");
});
*/
