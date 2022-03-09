$("a").not(".NoLoader").not(".close").click(function () {
    showLoader()
});
$("button").not(".NoLoader").not(".close").click(function () {
    showLoader()
});
//showLoader()
//setTimeout(hideLoader, 200)
/*document.getElementsByTagName("main")[0].classList.toggle("slideInFromLeftContainer")*/
function hideLoader() {
    document.getElementById("loaderContainer").style.display = "none"
}
function showLoader() {
    document.getElementById("loaderContainer").style.display = "block"
/*    document.getElementsByTagName("main")[0].classList.toggle("slideOutToLeftContainer")*/
}
