setPrompt() {
    if git status >/dev/null 2>&1; then
        printf "Modified files: %s" "$(git diff --name-only 2>/dev/null | wc -l)"
    else
        printf "Free: %s, Files: %s" "$(df -h --output=avail . | tail -n1)" "$(ls | wc -l)"
    fi
}

export PS1='[$(setPrompt)]\$ '
