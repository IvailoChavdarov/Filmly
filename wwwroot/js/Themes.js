var theme = localStorage.getItem("theme")
function switchTheme() {
    if (theme == "dark") {
        localStorage.setItem("theme", "light")
        document.querySelector("body").classList.remove("darkTheme")
        document.getElementById('themeIdenticator').classList.remove("fa-moon")
        document.getElementById('themeIdenticator').classList.add("fa-sun")
        document.getElementById('themeIdenticatorMobile').classList.remove("fa-moon")
        document.getElementById('themeIdenticatorMobile').classList.add("fa-sun")
        theme = "light"
    }
    else {
        localStorage.setItem("theme", "dark")
        document.querySelector("body").classList.add("darkTheme")
        document.getElementById('themeIdenticator').classList.remove("fa-sun")
        document.getElementById('themeIdenticator').classList.add("fa-moon")
        document.getElementById('themeIdenticatorMobile').classList.remove("fa-sun")
        document.getElementById('themeIdenticatorMobile').classList.add("fa-moon")
        theme = "dark"
    }
}
function handleIcon() {
    if (theme == "dark") {
        document.getElementById('themeIdenticator').classList.add("fa-moon")
        document.getElementById('themeIdenticatorMobile').classList.add("fa-moon")
        document.querySelector("body").classList.add("darkTheme")
    }
    else {
        document.getElementById('themeIdenticator').classList.add("fa-sun")
        document.getElementById('themeIdenticatorMobile').classList.add("fa-sun")
    }
/*    console.log(theme);*/
}

////var theme = localStorage.getItem("theme")
////var themeSwitcher = document.querySelector("#themeSwitcher")
////var themeSwitchContainer = document.querySelector("#themeSwitchContainer")

////function changeTheme() {
////    if (theme == "dark") {
////        localStorage.setItem("theme", "light")
////        document.querySelector("body").classList.remove("body-darkTheme")
////        document.getElementById('mobileThemeChanger').classList.remove("mobile-theme-identicator-box-dark");
////        document.getElementById('theme-identicator-mobile').classList.remove("fa-moon")
////        document.getElementById('theme-identicator-mobile').classList.add("fa-sun")
////        theme = "light"
////    }
////    else {
////        localStorage.setItem("theme", "dark")
////        document.querySelector("body").classList.add("body-darkTheme")
////        document.getElementById('mobileThemeChanger').classList.add("mobile-theme-identicator-box-dark");
////        document.getElementById('theme-identicator-mobile').classList.remove("fa-sun")
////        document.getElementById('theme-identicator-mobile').classList.add("fa-moon")
////        theme = "dark"
////    }
////}
////function renderTheme() {
////    if (typeof (Storage) !== "undefined") {
////        if (theme) {
////            if (theme == "dark") {
////                document.querySelector("body").classList.add("body-darkTheme")
////            }
////            if (theme == "light") {
////                if (document.querySelector("body").classList.contains("body-darkTheme")) {
////                    document.querySelector("body").classList.remove("body-darkTheme")
////                }
////            }
////        }
////    } else {
////        themeSwitchContainer.style.display = none;
////    }
////    /*console.log(theme);*/
////}
//(function () {
//    if (localStorage.getItem('theme') === 'dark') {
//        document.getElementById('themeSwitcher').checked = true;
//        document.getElementById('mobileThemeChanger').classList.add("mobile-theme-identicator-box-dark");
//        document.getElementById('theme-identicator-mobile').classList.add("fa-moon")
//    } else {
//        document.getElementById('themeSwitcher').checked = false;
//        document.getElementById('theme-identicator-mobile').classList.add("fa-sun")
//    }
//    renderTheme()
//})();