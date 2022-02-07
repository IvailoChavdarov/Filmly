var scrolled_Y = 0
function scrollTo(id) {
    //document.querySelector('#eventsContainer').scrollTo({
    //    top: getOffset(document.getElementById(id)).top,
    //    left: 100,
    //    behavior: 'smooth'
    //});
    document.querySelector('#eventsContainer').scrollTop = document.getElementById(id).offsetTop-100
    /*document.querySelector('#eventsContainer').scrollTop = getOffset(document.getElementById(id)).top*/
   /*console.log(getOffset(document.getElementById(id)).top);*/
}
function getOffset(el) {
    const rect = el.getBoundingClientRect();
    return {
        left: rect.left + window.scrollX,
        top: rect.top + window.scrollY
    };
}

document.querySelectorAll(".EventScroll").forEach((e) => {
    e.addEventListener('click', ev => {
        scrollTo(e.id+"_data")
    })
})