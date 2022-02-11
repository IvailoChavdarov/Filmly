const slideFromLeftElements = [
    '.servicesContainer',
    '.card-deck',
    '.showcase'
]
const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('slideFromLeft');
        }
    });
});
slideFromLeftElements.forEach(cl => {
    document.querySelectorAll(cl).forEach(el => {
        observer.observe(el);
    })
})