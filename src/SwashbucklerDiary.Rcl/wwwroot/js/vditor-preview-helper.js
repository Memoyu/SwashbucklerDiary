export function previewVditor(dotNetCallbackRef, element, text, options) {
    let VditorOptions = {
        ...options,
        after: () => {
            fixLink(element);
            fixCopyDisplaySoftKeyboard(element);
            fixVideoNotDisplayFirstFrame(element);
            fixIframeAllowFullscreen(element);
            dotNetCallbackRef.invokeMethodAsync('After');
        }
    }
    Vditor.preview(element, text, VditorOptions);
}

export function copy(dotNetCallbackRef, callbackMethod, element) {
    const items = element.querySelectorAll('.vditor-copy');
    items.forEach(item => {
        item.addEventListener('click', function () {
            dotNetCallbackRef.invokeMethodAsync(callbackMethod);
        });
    });
}

export function previewImage(dotNetCallbackRef, callbackMethod, element) {
    const imgs = element.querySelectorAll("img");
    imgs.forEach(img => {
        img.addEventListener('click', function () {
            dotNetCallbackRef.invokeMethodAsync(callbackMethod, this.getAttribute('src'));
        });
    });
}

//修复点击链接的一些错误
function fixLink(element) {
    const links = element.querySelectorAll("a"); // 获取所有a标签
    links.forEach(link => {
        var href = link.getAttribute('href');
        if (href && !href.includes(':')) {
            href = "https://" + href;
            link.setAttribute("href", href); // 修改每个a标签的href属性
        };
    });
}

function fixCopyDisplaySoftKeyboard(element) {
    const textareas = element.querySelectorAll("textarea"); // 获取所有textarea标签
    textareas.forEach(textarea => {
        textarea.readOnly = true;
    });
}

function fixVideoNotDisplayFirstFrame(element) {
    const videos = element.querySelectorAll("video");
    videos.forEach(video => {
        video.playsInline = "true";
        if (video.hasAttribute('src')) {
            const url = new URL(video.src);
            if (!url.hash) {
                video.src += '#t=0.1';
            }

            return;
        }
        
        const sources = video.querySelectorAll('source');
        
        sources.forEach(source => {
            const url = new URL(source.src);
            if (!url.hash) {
                source.src += '#t=0.1';
            }
        });
    });
}

function fixIframeAllowFullscreen(element) {
    const iframes = element.querySelectorAll("iframe");
    iframes.forEach(iframe => {
        iframe.allowFullscreen = true;
    });
}
