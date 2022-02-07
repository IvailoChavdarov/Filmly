//handle menu dropdown
var dropdownNav = document.getElementById("topNavDropdown")
$('#homeDropdownButton').on('click', function () {
	$('#topNavDropdown').toggleClass('open');
	if (dropdownNav.classList.contains('open')) {
		document.getElementById('homeDropdownIndicator').id = 'homeDropdownIndicator-triggered'
	}
	else {
		document.getElementById('homeDropdownIndicator-triggered').id = 'homeDropdownIndicator'
	}
});
$('#scrollArrow').on('click', function () {
	window.scrollTo({ top: 0, behavior: 'smooth' });
})

window.onscroll = function () { handleScrollArrow()};
function handleScrollArrow() {
	if (window.scrollY > window.innerHeight/1.5) {
		document.getElementById('scrollArrow').style.display = "inline-block"
	}
	else {
		document.getElementById('scrollArrow').style.display = "none"
	}
}
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
    console.log(theme);
}

document.getElementById('mobileMenu').style.height = window.innerHeight - 70;

function toggleMobileMenu() {
    $('#mobileMenu').toggleClass('open');
    $('body').toggleClass('overflow-hidden');
    $('#mobileMenuToggler').toggleClass('open');
}
handleScrollArrow()
handleIcon()
if (document.getElementsByTagName('body')[0].clientHeight < window.innerHeight) {
    document.getElementById('pageFooter').style.position="absolute"
}