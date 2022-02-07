$("a").not(".NoLoader").click(function () {
    showLoader()
});
$("button").not(".NoLoader").click(function () {
    showLoader()
});
//showLoader()
//setTimeout(hideLoader, 200)
function hideLoader() {
    document.getElementById("loaderContainer").style.display = "none"
}
function showLoader() {
    document.getElementById("loaderContainer").style.display = "block"
}
