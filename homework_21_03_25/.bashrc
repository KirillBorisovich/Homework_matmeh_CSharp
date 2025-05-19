PS1='[$(
    if git status >/dev/null 2>&1; then 
        echo "Modified files: $(git diff --name-only 2>/dev/null | wc -l)";
    else
        echo "Free: $(df -h --output=avail . | tail -n1), Files: $(ls | wc -l)";
    fi
)] '
