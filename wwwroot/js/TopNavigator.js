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
    document.body.scrollTo({ top: 0, behavior: 'smooth' });
    document.getElementById('scrollArrow').style.display = "none"
})

$(document.body).on('touchmove', handleScrollArrow);
window.onscroll = function () { handleScrollArrow() };

function handleScrollArrow() {
	if (window.scrollY > window.innerHeight/1.5) {
        document.getElementById('scrollArrow').style.display = "inline-block";
	}
	else {
		document.getElementById('scrollArrow').style.display = "none"
    }
    if (window.innerWidth <= 991) {
        if (document.body.scrollTop >= window.innerHeight / 1.5) {
            document.getElementById('scrollArrow').style.display = "inline-block";
        }
        else {
            document.getElementById('scrollArrow').style.display = "none"
        }
    }

}



document.getElementById('mobileMenu').style.height = window.innerHeight - 70;

function toggleMobileMenu() {
    $('#mobileMenu').toggleClass('open');
    $('body').toggleClass('overflow-hidden');
    $('#mobileMenuToggler').toggleClass('open');
}
handleScrollArrow()
handleIcon()
if (document.getElementsByTagName('body')[0].height < window.innerHeight - 100) {
    document.getElementById('pageFooter').style.position="absolute"
}