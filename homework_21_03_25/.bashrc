isGitRepository() {
    git rev-parse --git-dir &> \dev\null
}

setPrompt() {
    if isGitRepository; then
        PS1="[Modified files: $(git diff --name-only | wc -l)]"
    else
        PS1="[Free: $(df -h . | awk 'NR==2 {print $4}'), Files: $(ls -1 | wc -l)] "
    fi
}

PROMPT_COMMAND=setPrompt