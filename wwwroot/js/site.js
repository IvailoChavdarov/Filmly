var topNav = document.getElementById("topNav")
var dropdownNav = $('.homeDropdownBox')[0]
//$(document).ready(function () {
//	$('#nav-icon3').click(function () {
//		$(this).toggleClass('open');
//	});
//	handleNavColor()
//});

document.querySelectorAll(".menuCollapseButton").forEach((el) => {
	el.addEventListener('click', () => {
		var collapseIcon = [...el.children].filter(child => child.classList.contains("collapseIcon-all"))[0];
		collapseIconFunc(collapseIcon)
	})
})
function collapseIconFunc(collapseIcon) {
	if (collapseIcon.classList.contains("collapseIcon")) {
		collapseIcon.classList.remove("collapseIcon")
		collapseIcon.classList.add("collapsedIcon")
	}
	else {
		collapseIcon.classList.remove("collapsedIcon")
		collapseIcon.classList.add("collapseIcon")
	}
}


/*window.onscroll = function () { handleNavColor() };*/

//function handleNavColor() {
//	if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
//		if (topNav.classList.contains("topNav-transparent")) {
//			topNav.classList.remove("topNav-transparent")
//			if (dropdownNav.classList.contains("bg-transparent")) {
//				dropdownNav.classList.remove("bg-transparent")
//			}
//			if (topNav.classList.contains("bg-semi-transparent")) {
//				topNav.classList.remove("bg-semi-transparent")
//            }
//        }
//	} else {
//		if (!topNav.classList.contains("topNav-transparent")) {
//			topNav.classList.add("topNav-transparent")
//			if (!dropdownNav.classList.contains("bg-transparent")) {
//				dropdownNav.classList.add("bg-transparent")
//			}
//			if (dropdownNav.classList.contains("homeDropdownBox-show")) {
//				if (!topNav.classList.contains("bg-semi-transparent")) {
//					topNav.classList.add("bg-semi-transparent")
//                }
//            }
//        }
//	}
//}
//function addOrRemoveFromClassList(el, className) {
//	if (el.classList.contains(className)) {
//		el.classList.remove(className)
//	}
//	else {
//		el.classList.add(className)
//    }
//}