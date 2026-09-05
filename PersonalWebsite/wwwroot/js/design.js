const io = new IntersectionObserver((entries) => {
    entries.forEach((entry) => {
        if (entry.isIntersecting) {
            entry.target.classList.add('in-view');
        }
    });
}, { threshold: 0.2 });

document.querySelectorAll('.reveal').forEach((el) => io.observe(el));

document.querySelectorAll('.skill').forEach((el) => {
    el.style.setProperty('--w', el.dataset.pct + '%');
});

const DEVICON = (slug, variant = 'original') =>
    `https://cdn.jsdelivr.net/gh/devicons/devicon/icons/${slug}/${slug}-${variant}.svg`;

const techStack = [
    { name: 'C#', icon: DEVICON('csharp') },
    { name: '.NET', icon: DEVICON('dotnetcore') },
    { name: 'ASP.NET Core', icon: DEVICON('dotnetcore'), invert: false },
    { name: 'Entity Framework Core', icon: null, glyph: 'db' },
    { name: 'SQL Server', icon: DEVICON('microsoftsqlserver', 'plain') },
    { name: 'PostgreSQL', icon: DEVICON('postgresql') },
    { name: 'MongoDB', icon: DEVICON('mongodb') },
    { name: 'Redis', icon: DEVICON('redis') },
    { name: 'Docker', icon: DEVICON('docker') },
    { name: 'Kubernetes', icon: DEVICON('kubernetes', 'plain') },
    { name: 'Azure', icon: DEVICON('azure') },
    { name: 'Git', icon: DEVICON('git') },
    { name: 'GitHub', icon: DEVICON('github'), invert: true },
    { name: 'JavaScript', icon: DEVICON('javascript') },
    { name: 'React', icon: DEVICON('react') },
];

const dbGlyph = `<svg viewBox="0 0 24 24" width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.6"><ellipse cx="12" cy="5" rx="8" ry="3"/><path d="M4 5v6c0 1.66 3.58 3 8 3s8-1.34 8-3V5"/><path d="M4 11v6c0 1.66 3.58 3 8 3s8-1.34 8-3v-6"/></svg>`;

function techItem(t) {
    const item = document.createElement('div');
    item.className = 'tech-item';
    const badge = document.createElement('span');
    badge.className = 'tech-badge' + (t.invert ? ' tech-badge-invert' : '');
    if (t.icon) {
        const img = document.createElement('img');
        img.src = t.icon;
        img.alt = t.name;
        img.loading = 'lazy';
        badge.appendChild(img);
    } else {
        badge.innerHTML = dbGlyph;
    }
    const label = document.createElement('span');
    label.className = 'tech-name';
    label.textContent = t.name;
    item.appendChild(badge);
    item.appendChild(label);
    return item;
}

const track = document.getElementById('techTrack');
if (track) {
    [...techStack, ...techStack].forEach((t) => track.appendChild(techItem(t)));
}

const statuses = ['Open to Work!', 'Open to Intern!', 'Open to Remote!'];

function statusItem(text) {
    const item = document.createElement('div');
    item.className = 'status-item';
    const dot = document.createElement('span');
    dot.className = 'dot-sep';
    const label = document.createElement('span');
    label.textContent = text;
    item.appendChild(dot);
    item.appendChild(label);
    return item;
}

const statusTrack = document.getElementById('statusTrack');
if (statusTrack) {
    [...statuses, ...statuses, ...statuses, ...statuses].forEach((s) => statusTrack.appendChild(statusItem(s)));
}