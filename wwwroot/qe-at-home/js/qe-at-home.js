// QE@Home: opens and closes the full-screen menu, and keeps the current
// section visible in the scrolling section bar on small screens.
(function () {
  var overlay = document.getElementById('overlay');
  var menuBtn = document.getElementById('menuBtn');
  var closeBtn = document.getElementById('closeBtn');
  if (!overlay || !menuBtn || !closeBtn) return;

  function setMenu(open) {
    overlay.classList.toggle('open', open);
    menuBtn.setAttribute('aria-expanded', open ? 'true' : 'false');
    document.body.style.overflow = open ? 'hidden' : '';
    if (open) closeBtn.focus(); else menuBtn.focus();
  }

  menuBtn.addEventListener('click', function () { setMenu(true); });
  closeBtn.addEventListener('click', function () { setMenu(false); });
  document.addEventListener('keydown', function (e) {
    if (e.key === 'Escape' && overlay.classList.contains('open')) setMenu(false);
  });

  var current = document.querySelector('#subnav a[aria-current="page"]');
  if (current && current.scrollIntoView) {
    current.scrollIntoView({ block: 'nearest', inline: 'center' });
    window.scrollTo(0, 0);
  }
})();
