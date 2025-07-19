
window.isOnline = async () => {
    if (!navigator.onLine) return false;

    try {
        const response = await fetch("/Ping", {
            method: "HEAD",
            cache: "no-store"
        });
        return response.ok;
    } catch {
        return false;
    }
};


/*window.isOnline = () => true;*/

